using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong
{
    public class NavManager
    {
        private readonly Panel _host;
        private readonly Dictionary<string, Func<UserControl>> _factories = new Dictionary<string, Func<UserControl>>();

        public NavManager(Panel host)
        {
            _host = host;
        }

        public void Register(string key, Func<UserControl> factory)
        {
            _factories[key] = factory;
        }

        public void Show(string key, object reloadArg = null)
        {
            if (!_factories.ContainsKey(key))
                throw new InvalidOperationException("Không tìm thấy view: " + key);

            _host.SuspendLayout();

            if (_host.Controls.Count > 0)
            {
                var old = _host.Controls[0];
                _host.Controls.Clear();
                old.Dispose();
            }

            // Tạo mới và hiển thị
            var uc = _factories[key]();
            uc.Dock = DockStyle.Fill;
            _host.Controls.Add(uc);

            // Gọi Reload() nếu UC có implement interface
            var reloadable = uc as IReloadable;
            if (reloadable != null)
            {
                reloadable.Reload(reloadArg);
            }

            _host.ResumeLayout(true);
            _host.Refresh();
        }
    }
}
