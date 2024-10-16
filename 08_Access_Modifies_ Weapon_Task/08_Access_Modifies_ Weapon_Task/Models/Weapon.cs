using System;
using System.Media;

namespace _08_Access_Modifies__Weapon_Task.Models
{
    class Weapon
    {
        private int _magazineCapacity;
        private int _bulletCount;
        private double _outOfAmmoSec;
        private string _fireMode = "single";

        public int MagazineCapacity
        {
            get { return _magazineCapacity; }
            set
            {
                if (value >= 1) _magazineCapacity = value;
                else Console.WriteLine("Ammo can not be minus!");
            }
        }

        public int BulletCount
        {
            get { return _bulletCount; }
            set
            {
                if (value <= _magazineCapacity && value >= 0) _bulletCount = value;
                else Console.WriteLine($"Invalid bullet input, minus or out of magazine");
            }
        }

        public double OutOfAmmoSec
        {
            get { return _outOfAmmoSec; }
            set
            {
                if (value > 0) _outOfAmmoSec = value;
                else Console.WriteLine("Minus second? You are time traveler");
            }
        }

        public string FireMode
        {
            get { return _fireMode; }
            set
            {
                if (value.ToLower().Trim() == "single" || value.ToLower().Trim() == "auto") _fireMode = value.ToLower().Trim();
                else Console.WriteLine("Fire mode can be only auto or single");
            }
        }

        public Weapon(int magazineCapacity, int bulletCount, double outOfAmmoSec)
        {
            MagazineCapacity = magazineCapacity;
            BulletCount = bulletCount;
            OutOfAmmoSec = outOfAmmoSec;
        }

        public void ChangeFireMode()
        {
            if (FireMode == "auto")
            {
                Console.Write($"Fire mode {FireMode} ");
                FireMode = "single";
                Console.WriteLine($"successfully chaged to {FireMode}");
            }
            else if (FireMode == "single")
            {
                Console.Write($"Fire mode {FireMode} ");
                FireMode = "auto";
                Console.WriteLine($"successfully chaged to {FireMode}");
            }
        }

        public void Shoot()
        {
            if (WantedReload())
            {
                if (BulletCount >= 1)
                {
                    PlaySound("shoot.wav");
                    BulletCount--;
                    Console.WriteLine($"1 bullet fired in {1 / (float)OutOfAmmoSec} sec, {BulletCount} bullets remains\n");
                }
                else Console.WriteLine("You don't have enough bullet to shoot!");
            }
        }

        public void Fire()
        {
            if (FireMode == "single")
            {
                if (WantedReload())
                {
                    Shoot();
                }
                else Console.WriteLine($"You have {BulletCount} ammo so you can not fire ");
            }
            else if (FireMode == "auto")
            {
                if (WantedReload())
                {
                    PlaySound("fire.wav");
                    Console.WriteLine($"{BulletCount} bullets fired in auto mode in {(float)(BulletCount * OutOfAmmoSec) / MagazineCapacity} sec. 0 bullet remains\n");
                }
                else Console.WriteLine($"You have {BulletCount} ammo so you can not fire");
                BulletCount = 0;
            }
        }

        public void Reload()
        {
            PlaySound("reload.wav");
            BulletCount = MagazineCapacity;
            Console.WriteLine($"\nWeapon reloaded, now it have {_bulletCount} bullets\n");
        }

        public bool WantedReload()
        {
            string isWanted = "yes";
            if (BulletCount == 0)
            {
                Console.Write($"You have {BulletCount} bullets, do you want to reload your weapon? (yes/no)\t");
                isWanted = Console.ReadLine().ToLower().Trim();

                if (isWanted == "yes") Reload();
                else Console.WriteLine($"\nWeapon not reloaded, bullet is {BulletCount}");
            }

            return isWanted == "yes";
        }

        public void GetRemainBulletCount()
        {
            Console.WriteLine($"Weapon need {MagazineCapacity - BulletCount} bullets for full magazine");
        }

        public void WeaponInfo()
        {
            Console.WriteLine($"\nMagazine Capacity: {_magazineCapacity}\nCurrent Bullets: {_bulletCount}\nOut of ammo: {_outOfAmmoSec} sec\nFire mode: {_fireMode}\n");
        }

        static void PlaySound(string path)
        {
            try
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = path;
                player.Play();
            } catch (Exception e)
            {
                
            }
        }
    }
}
