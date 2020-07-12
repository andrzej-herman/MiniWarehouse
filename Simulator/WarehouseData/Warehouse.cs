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
