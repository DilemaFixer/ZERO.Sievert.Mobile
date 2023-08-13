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

        public int GetMaximumAmountAvailableProjectile(int rightAmount)
        {
            if (_ammoCount >= rightAmount)
            {
                ConsumeAmmo(rightAmount);
                return rightAmount;
            }

            int currentAmountOfProjectile = _ammoCount;
            ConsumeAmmo(_ammoCount);
            return currentAmountOfProjectile;
        }
        
        public bool HasProjectile()
        {
            return _ammoCount > 0;
        }
    }
}