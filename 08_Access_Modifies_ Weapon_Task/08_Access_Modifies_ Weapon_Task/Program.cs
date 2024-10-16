using _08_Access_Modifies__Weapon_Task.Models;
using System;
using System.Media;

namespace _08_Access_Modifies__Weapon_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, youre welcome to The Weapon Game\n");
            Console.Write("Press enter to start!");
            Console.ReadLine();
            PlaySound("reload-and-shoot.wav"); //playing sound

            Console.WriteLine("\n0 - Weapon info\n1 - Shoot weapon\n2 - Firing weapon\n3 - Get remaining bullets for full magazine");
            Console.WriteLine("4 - Reload weapon\n5 - Change fire mode\n6 - Exit from poligon\n");
            Weapon akm = new Weapon(30, 25, 3);

            bool isPlaying = true;
            int code;
            while (isPlaying)
            {
                Console.Write("\nTry to permorm an act with weapon: ");
                code = Convert.ToInt32(Console.ReadLine());

                switch (code)
                {
                    case 0:
                        akm.WeaponInfo();
                        break;
                    case 1:
                        akm.Shoot();
                        break;
                    case 2:
                        akm.Fire();
                        break;
                    case 3:
                        akm.GetRemainBulletCount();
                        break;
                    case 4:
                        akm.Reload();
                        break;
                    case 5:
                        akm.ChangeFireMode();
                        break;
                    case 6:
                        Console.WriteLine("\nYou exit from the game!");
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid number!");
                        Console.WriteLine("\n0 - Weapon info\n1 - Shoot weapon\n2 - Firing weapon\n3 - Get remaining bullets for full magazine");
                        Console.WriteLine("4 - Reload weapon\n5 - Change fire mode\n6 - Exit from poligon\n");
                        break;
                }
            }
        }
        static void PlaySound(string path)
        {
            try
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = path;
                player.Play();
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
