namespace Game.Weapon
{
    public class AmmoHolder
    {
        // Is temporary script for projectile
        private int _ammoCount;

        public AmmoHolder(int initialAmmoCount)
        {
            _ammoCount = initialAmmoCount;
        }

        public void ConsumeAmmo(int amount)
        {
            _ammoCount -= amount;
        }
        
        public void AddAmmo(int amount)
        {
            _ammoCount += amount;
        }

        public bool HasAmmo(int amount)
        {
            return _ammoCount >= amount;
        }
        
        public bool HasAmmo()
        {
            return _ammoCount > 0;
        }
    }
}