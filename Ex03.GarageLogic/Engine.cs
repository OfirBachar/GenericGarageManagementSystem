using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_RemainingPower;
        public float RemainingPower
        {
            get => m_RemainingPower;
            set
            {
                if (Garage.IsInputInRange(value, 0, MaxPower))
                {
                    m_RemainingPower = value;
                }
            }
        }

        public float MaxPower { get; }

        protected Engine(float i_MaxPower)
        {
            MaxPower = i_MaxPower;
        }

        public virtual void AddPowerToEngine(float i_AddPower, FuelEngine.eFuelTypes? i_FuelType = null)
        {
            RemainingPower += i_AddPower;
        }
    }
}
