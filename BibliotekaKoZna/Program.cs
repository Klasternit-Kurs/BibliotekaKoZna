using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKoZna
{
	/*TODO
	 * Izmena i brisanje za korisnike i knjige
	 * Upis i citanje iz fajlova
	 * Provere pri iznajmljivanju. Ne izdajemo vise kopija iste knjige istom clanu. Maksimalno tri knjige u
	 * jednom momentu.
	 * Vracanje knjiga (obavezno dodati na broj kopija :) )
	 * Ne moze da se iznajmi knjiga ako se kasni sa clanarinom
	 * 
	 */
	class Program
	{
		static List<Clan> Clanovi = new List<Clan>();
		static List<Knjiga> Knjige = new List<Knjiga>();
		static void Main(string[] args)
		{
			string unos;
			do
			{
				Meni();
				unos = Console.ReadKey().KeyChar.ToString();
				Console.WriteLine();

				switch(unos)
				{
					case "0":
						Iznajmi();
						break;
					case "1":
						UnosClana();
						break;
					case "4":
						IspisClanova();
						break;
					case "5":
						UnosKnjige();
						break;
					case "9":
						Console.WriteLine("Bye :)");
						break;
					default:
						Console.WriteLine("Greska u unosu :(");
						break;
				}

			} while (unos != "9");

			Console.ReadKey();
		}

		static void Iznajmi()
		{
			Console.Write("Sifra clana: ");
			int sifra = int.Parse(Console.ReadLine());

			Clan c = null;
			foreach(Clan cc in Clanovi)
			{
				if (cc.ClanskiBr == sifra)
				{
					c = cc;
					break;
				}
			}
			if (c == null)
			{
				Console.WriteLine("Nope, nema clana");
				return;
			}

			Console.Write("Sifra knjige: ");
			sifra = int.Parse(Console.ReadLine());

			Knjiga k = null;
			foreach (Knjiga kk in Knjige)
			{
				if (kk.Sifra == sifra)
				{
					k = kk;
					break;
				}
			}
			if (k == null)
			{
				Console.WriteLine("Nope, nema knjige");
				return;
			}

			if (k.BrojKopija == 0)
			{
				Console.WriteLine("Nema");
				return;
			}

			c.KnjigeKodClana.Add(k);
			k.BrojKopija--;
		}

		static void UnosKnjige()
		{
			Knjiga k = new Knjiga();
			k.Sifra = Knjige.Count + 1;

			Console.Write("Unesite naziv: ");
			k.Naziv = Console.ReadLine();
			Console.Write("Unesite zanr: ");
			k.Zanr = Console.ReadLine();
			Console.Write("Unesite broj kopija: ");
			k.BrojKopija = int.Parse(Console.ReadLine());

			Knjige.Add(k);
		}
		static void IspisClanova()
		{
			Console.WriteLine("-----------------------------------");
			foreach(Clan c in Clanovi)
			{
				Console.Write($"{c.ClanskiBr}-{c.Ime} {c.Prezime} ");
				if (DateTime.Now.Month == c.ZadnjaClanarina.Month && DateTime.Now.Year == c.ZadnjaClanarina.Year)
				{
					Console.WriteLine("Placeno");
				} else
				{
					Console.WriteLine($"Kasni {(DateTime.Now.Date - c.ZadnjaClanarina.Date).Days} dana");
				}
				if (c.KnjigeKodClana.Count > 0)
				{
					Console.WriteLine("Knjige kod clana: ");
				}
				foreach(Knjiga k in c.KnjigeKodClana)
				{
					Console.WriteLine($"{k.Sifra}-{k.Naziv}");
				}
				Console.WriteLine("---------------");
			}
			Console.WriteLine("-----------------------------------");
		}

		static void UnosClana()
		{
			//TODO napraviti finu kontrolu unosa, kao kod POS-a 
			Console.Write("Unesite ime i prezime: ");
			//isto je, samo imamo listu :) 
			//string[] ImeIPrezime = Console.ReadLine().Split(' ');

			List<string> ImeIPrezime = new List<string>(Console.ReadLine().Split(' '));

			if (ImeIPrezime.Count != 2)
			{
				Console.WriteLine("Jok");
				return;
			}

			Clan c = new Clan(ImeIPrezime[0], ImeIPrezime[1]);
			c.ClanskiBr = (uint)Clanovi.Count + 1;
			Clanovi.Add(c);
		}

		static void Meni()
		{
			Console.WriteLine("0-Iznajmljivanje");
			Console.WriteLine("1-Unos korisnika");
			Console.WriteLine("2-Izmena korisnika");
			Console.WriteLine("3-Brisanje korisnika");
			Console.WriteLine("4-Ispis korisnika");
			Console.WriteLine("5-Unos knjige");
			Console.WriteLine("6-Izmena knjige");
			Console.WriteLine("7-Brisanje knjige");
			Console.WriteLine("8-Ispis knjiga");
			Console.WriteLine("9-Izlaz");
			Console.WriteLine("============================");
			Console.Write("Unesite izbor: ");
		}
	}
}
