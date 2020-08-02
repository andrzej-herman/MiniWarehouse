using Simulator.Controls;
using Simulator.Helpers;
using Simulator.Production;
using Simulator.WarehouseData;
using Simulator.WarehouseData.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Database
{
    public static class Mapper
    {
        public static Product DbProductToProduct(Produkty db)
        {
            return new Product
            {
                Id = db.ProduktId,
                Name = db.Nazwa,
                ExpirationDays = db.TerminPrzydatnosiWDniach
            };
        }

        public static Batch DbBatchToBatch(Partie db)
        {
            return new Batch
            {
                Id = db.PartiaId,
                BatchNumber = db.NumerPartii,
                ProductId = db.ProduktId,
                DateCreated = db.DataUtworzenia,
                NumberOfPallets = db.IloscPalet,
            };
        }

        public static BatchPallet DbBatchPalletToBatchPallet(PartiePalety db)
        {
            return new BatchPallet
            {
                Id = db.PaletaId,
                Symbol = db.Oznaczenie,
                Barcode = db.KodKreskowy,
                BatchId = db.PartiaId,
                StateId = db.StateId
            };
        }

        public static Pallet DbPalletToPalet(Palety db)
        {
            PalletType type = (PalletType)Convert.ToInt32(db.KodKreskowy.Substring(2, 1));
            var pallet = new Pallet
            {
                Id = db.PaletaId,
                Symbol = db.Oznaczenie,
                Barcode = db.KodKreskowy,
                ProductName = db.NazwaProduktu,
                BatchNumber = db.NumerPartiiProdukcyjnej,
                ExpirationDate = db.TerminPrzydatnosci,
                ProductionDate = db.DataProdukcji,
                Destination = db.Destynacja,
                State = (PalletState)db.Stan,
                Type = type,
                PcId = db.PcId
            };

            pallet.Display = new ucPallet();
            pallet.Display.Init(pallet);
            return pallet;
  
        }

        public static Palety PalletToDbPalet(Pallet p)
        {
            return new Palety
            {
               PaletaId = p.Id,
               Oznaczenie = p.Symbol,
               KodKreskowy = p.Barcode,
               NazwaProduktu = p.ProductName,
               NumerPartiiProdukcyjnej = p.BatchNumber,
               TerminPrzydatnosci = p.ExpirationDate,
               DataProdukcji = p.ProductionDate,
               Destynacja = p.Destination,
               PcId = p.PcId,
               Stan = (int)p.State
            };
        }

        public static Position DbPositionToPosition(Pozycje db)
        {
            Position result;
            PositionType type = (PositionType)db.Typ;
            switch (type)
            {
                case PositionType.Production:
                    result = new PosProduction(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type, 
                        db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.LiftEnter:
                    result = new PosLiftEnter(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                        db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Lift:
                    result = new PosLift(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                        db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Control:
                    result = new PosControl(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                       db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.MainEnter:
                    result = new PosMainEnter(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                        db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Repair:
                    result = new PosRepair(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                       db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Inspection:
                    result = new PosInspection(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                      db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Cross:
                    result = new PosCross(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                     db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Ramp:
                    result = new PosRamp(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                        db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.RampEnter:
                    result = new PosRampEnter(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                       db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Standard:
                    result = new PosStandard(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                        db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.WarehouseEnter:
                    result = new PosWarehouseEnter(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                       db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Warehouse:
                    result = new PosWarehouse(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                        db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.Master:
                    result = new PosMaster(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                       db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.BatteryZero:
                    result = new PosBatteryZero(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                       db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                case PositionType.BatteryOne:
                    result = new PosBatteryOne(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                       db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
                default:
                    result = new PosStandard(db.PozycjaId, db.Szerokosc, db.Wysokosc, db.X, db.Y, db.Poziom, type,
                        db.Przod, db.Tyl, db.Lewo, db.Prawo, db.Gora, db.Dol, db.Zatoka, db.Rampa, db.PaletaId, db.MasterId, db.PlcCommunication);
                    break;
            }

            return result;
        }

        public static Mission DbMissionToMission(Misje db)
        {
            return new Mission
            {
                Id = db.MisjaId,
                Type = (MissionType)db.TypMisji,
                PickPositionId = db.PozycjaOdbioruId,
                DropPositionId = db.PozycjaDostarczeniaId,
                PalletId = db.PaletaId,
                MasterId = db.MasterId,
                Status = (MissionStatus)db.Status
            };
        }

        public static Master DbMasterToMaster(Mastery db)
        {
            return new Master
            {
                Id = db.MasterId,
                Level = (Level)db.Poziom,
                Capacity = db.Capacity,
                ActiveMissionId = db.AktywnaMisjaId,
                Missions = new List<Mission>(),
                Display = new ucMaster()
            };
        }
    }
}





