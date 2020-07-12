using Simulator.Controls;
using Simulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator.WarehouseData
{
    public abstract class Position 
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Level Level { get; set; }
        public PositionType Type { get; set; }
        public int? Forward { get; set; }
        public int? Back { get; set; }
        public int? Left { get; set; }
        public int? Right { get; set; }
        public int? Up { get; set; }
        public int? Down { get; set; }
        public PositionDirection CurrentDirection { get; set; }
        public string Bay { get; set; }
        public string Ramp { get; set; }
        public int? Pid { get; set; }
        public string M { get; set; }
        public Pallet Pallet { get; set; }
        public Master Master { get; set; }
        public Dictionary<Site, Position> Neighbours { get; set; }
        private ucPosition Display { get; set; }

        public virtual bool CanHostPallet
        {
            get { return Pallet == null; }
        }

        public virtual bool CanMove
        {
            get 
            {
                return Pallet != null
                    && Neighbours[Site.Forward] != null
                    && Neighbours[Site.Forward].CanHostPallet;
            }
        }

        public Position(int id, int width, int height, int x, int y, int level, PositionType type, 
                        int? forward, int? back, int? left, int? right, int? up, int? down, string bay, string ramp, int? pid, bool m1, bool m2)
        {
            Id = id;
            Width = width;
            Height = height;
            X = x;
            Y = y;
            Level = (Level)level;
            Type = type;
            Forward = forward;
            Back = back;
            Left = left;
            Right = right;
            Up = up;
            Down = down;
            Bay = bay;
            Ramp = ramp;
            Pid = pid;
            M = m1 ? "M1" : m2 ? "M2" : null;
            Init();
        }

        public void CreatePosition(TabPage level_0, TabPage level_1)
        {
            Display = new ucPosition(this);
            Display.Init(level_0, level_1);
        }

        public void SetNeighbours(List<Position> positions)
        {
            Neighbours[Site.Forward] = Forward.HasValue ? positions.FirstOrDefault(p => p.Id == Forward.Value) : null;
            Neighbours[Site.Back] = Back.HasValue ? positions.FirstOrDefault(p => p.Id == Back.Value) : null;
            Neighbours[Site.Left] = Left.HasValue ? positions.FirstOrDefault(p => p.Id == Left.Value) : null;
            Neighbours[Site.Right] = Right.HasValue ? positions.FirstOrDefault(p => p.Id == Right.Value) : null;
            Neighbours[Site.Up] = Up.HasValue ? positions.FirstOrDefault(p => p.Id == Up.Value) : null;
            Neighbours[Site.Down] = Down.HasValue ? positions.FirstOrDefault(p => p.Id == Down.Value) : null;
        }

        public void ShowNumber()
        {
            Display.ShowNumber();
        }

        public void HideNumber()
        {
            Display.HideNumber();
        }

        public void MapPallet(Pallet p, bool invoke)
        {
            Pallet = p;
            Display.MapPallet(p, invoke);
        }

        public virtual void MapMaster(Master p)
        {

        }

        private void RemovePallet()
        {
            Pallet = null;
            Display.RemovePallet();
        }

        private void Init()
        {
            CurrentDirection = PositionDirection.Normal;
            Neighbours = new Dictionary<Site, Position>();
            var sites = Enum.GetValues(typeof(Site));
            foreach (var item in sites)
            {
                Neighbours.Add((Site)item, null); 
            }
        }

        public virtual void Move()
        {
            if (CanMove)
            {
                Neighbours[Site.Forward].MapPallet(Pallet, true);
                RemovePallet();
            }
        }



    }
}


/*
 *     OK [PozycjaId]
       OK [Szerokosc]
       OK [Wysokosc]
       OK [X]
       OK [Y]
       OK [Poziom]
       OK [Typ]
       OK [Przod]
       OK [Tyl]
       OK [Lewo]
       OK [Prawo]
       OK [Gora]
       OK [Dol]
       OK [AktualnyKierunek]
       OK [Zatoka]
       OK [Rampa]
      ,[Master1]
      ,[Master2]
      ,[PaletaId]
*/
