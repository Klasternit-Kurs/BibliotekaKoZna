using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKoZna
{
	class Clan
	{
		public string Ime;
		public string Prezime;
		public uint ClanskiBr;

		public DateTime ZadnjaClanarina = DateTime.Now.Date;

		public List<Knjiga> KnjigeKodClana = new List<Knjiga>();

		public Clan(string i, string p)
		{
			Ime = i;
			Prezime = p;
		}
	}
}
