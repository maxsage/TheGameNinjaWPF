using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameNinja.Desktop;

namespace TheGameNinja.Desktop.Accolades
{
    class AccoladeViewModel : BindableBase
    {
        private int _VideoGameId;

        public int VideoGameId
        {
            get { return _VideoGameId; }
            set { SetProperty(ref _VideoGameId, value); }
        }

    }
}
