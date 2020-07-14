using Simulator.Controls;
using Simulator.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator.WarehouseData
{
    public class Warehouse
    {
        private readonly SimulatorContext _dbContext;
        private List<Position> _positions;
        private List<Pallet> _pallets;

        public List<Position> Positions
        {
            get { return _positions; }
        }

        public List<Pallet> Pallets
        {
            get { return _pallets; }
        }


        public Warehouse(SimulatorContext context)
        {
            _dbContext = context;
            GetPositions();
            GetPallets();
        }


        public void CreateBayNumbers(TabPage level_0, TabPage level_1)
        {
            List<int> first = new List<int>() { 1025, 1021, 1017, 1013, 1009, 1005, 1001, 1003, 1007, 1011, 1015, 1019, 1023, 1027 };
            List<int> second = new List<int>() { 1026, 1022, 1018, 1014, 1010, 1006, 1002, 1004, 1008, 1012, 1016, 1020, 1024, 1028 };
            List<int> third = new List<int>() { 2002, 2004, 2006, 2008, 2010, 2012, 2014, 2016, 2018, 2020, 2022, 2024, 2026, 2028, 2030, 2032, 2034, 2036, 2038 };
            List<int> fourth = new List<int>() { 2003, 2005, 2007, 2009, 2011, 2013, 2015, 2017, 2019, 2021, 2023, 2025, 2027, 2029, 2031, 2033, 2035, 2037, 2039 };

            ucBaySign sign;

            int xfirst = 425;
            foreach (var item in first)
            {
                sign = new ucBaySign(item);
                sign.SetBounds(xfirst, 134, 33, 50);
                level_0.Controls.Add(sign);
                xfirst += 71;
            }

            int xsecond = 425;
            foreach (var item in second)
            {
                sign = new ucBaySign(item);
                sign.SetBounds(xsecond, 881, 33, 50);
                level_0.Controls.Add(sign);
                xsecond += 71;
            }

            int xthird = 496;
            foreach (var item in third)
            {
                sign = new ucBaySign(item);
                sign.SetBounds(xthird, 134, 33, 50);
                level_1.Controls.Add(sign);
                xthird += 71;
            }

            int xfourth = 496;
            foreach (var item in fourth)
            {
                sign = new ucBaySign(item);
                sign.SetBounds(xfourth, 881, 33, 50);
                level_1.Controls.Add(sign);
                xfourth += 71;
            }
        }


        public void CreatePositions(TabPage level_0, TabPage level_1)
        {
            foreach (var pos in _positions)
            {
                pos.CreatePosition(level_0, level_1);
            }
        }


        public void SetNeighbours()
        {
            foreach (var pos in _positions)
            {
                pos.SetNeighbours(_positions);
            }
        }

        public void MapMasters()
        {

        }

        public void MapPallets()
        {
            foreach (var pos in _positions)
            {
                if (pos.Pid.HasValue)
                {
                    var pallet = _pallets.FirstOrDefault(p => p.Id == pos.Pid);
                    pos.MapPallet(pallet, false);
                }
            }
        }

        public void Move()
        {
            foreach (var pos in _positions.OrderByDescending(p => p.Id).ToList())
            {
                pos.Move();
            }
        }

        public void ShowNumbers()
        {
            foreach (var pos in _positions)
            {
                pos.ShowNumber();
            }
        }

        public void HideNumbers()
        {
            foreach (var pos in _positions)
            {
                pos.HideNumber();
            }
        }

        public void SaveData()
        {
            foreach (var pos in _positions)
            {
                if (pos.Pallet != null)
                    _dbContext.Pozycje.FirstOrDefault(p => p.PozycjaId == pos.Id).PaletaId = pos.Pallet.Id;
                else
                    _dbContext.Pozycje.FirstOrDefault(p => p.PozycjaId == pos.Id).PaletaId = null;
            }

            _dbContext.SaveChanges();
        }

        private void GetPositions()
        {
            var db = _dbContext.Pozycje.OrderBy(d => d.PozycjaId).ToList();
            _positions = db.Select(p => Mapper.DbPositionToPosition(p)).ToList();

        }

        private void GetPallets()
        {
            var db = _dbContext.Palety.OrderBy(p => p.PaletaId).ToList();
            _pallets = db.Select(p => Mapper.DbPalletToPalet(p)).ToList();
        }
    }
}
