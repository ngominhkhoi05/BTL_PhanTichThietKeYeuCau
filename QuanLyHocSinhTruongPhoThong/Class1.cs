using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class NoBarFlowLayoutPanel : FlowLayoutPanel
{
    [DllImport("user32.dll")]
    private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);
    private const int SB_HORZ = 0, SB_VERT = 1;

    private int _targetY = 0;
    private Timer _timer;

    public NoBarFlowLayoutPanel()
    {
        AutoScroll = true;

        // Bật double-buffer để mượt layout
        typeof(Panel).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            ?.SetValue(this, true);

        _timer = new Timer { Interval = 10 };
        _timer.Tick += (s, e) => Animate();

        this.MouseWheel += (s, e) =>
        {
            int step = -(int)(e.Delta * 1.5);
            _targetY = Clamp(VerticalScroll.Value + step, 0, VerticalScroll.Maximum);
            if (!_timer.Enabled) _timer.Start();
        };

        this.MouseEnter += (s, e) => this.Focus();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        HideBars();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        HideBars();
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        base.OnControlAdded(e);
        HideBars();
    }

    protected override void OnControlRemoved(ControlEventArgs e)
    {
        base.OnControlRemoved(e);
        HideBars();
    }

    private void HideBars()
    {
        if (IsHandleCreated)
        {
            ShowScrollBar(this.Handle, SB_HORZ, 0);
            ShowScrollBar(this.Handle, SB_VERT, 0);
        }
    }

    private void Animate()
    {
        int cur = this.VerticalScroll.Value;
        int delta = _targetY - cur;

        if (Math.Abs(delta) <= 2)
        {
            SetY(_targetY);
            _timer.Stop();
            return;
        }
        int move = Math.Max(2, Math.Abs(delta) / 5) * Math.Sign(delta);
        SetY(cur + move);
    }

    private void SetY(int y)
    {
        y = Clamp(y, 0, this.VerticalScroll.Maximum);
        this.AutoScrollPosition = new Point(0, y);
        HideBars();
    }

    private static int Clamp(int v, int min, int max) => v < min ? min : (v > max ? max : v);
}

