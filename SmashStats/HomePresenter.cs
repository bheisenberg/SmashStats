using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashStats
{
    public class HomePresenter
    {
        public HomeView View;

        public HomePresenter(HomeView homeControl)
        {
            this.View = homeControl;
        }

        public void AttachToView()
        {
            View.Presenter = this;
        }

        public void LoadBaseData ()
        {
            Query query = new Query();
            List<Tuple<string, string>> data = new List<Tuple<string, string>>();
            data = query.LoadData();
            View.Data = data;
        }

        public void LoadTournamentsByDate (int year)
        {
            Query query = new Query();
            List<Tuple<string, string>> data;
            data = query.LoadTournamentsByDate(year);
            View.Data = data;
        }
    }
}