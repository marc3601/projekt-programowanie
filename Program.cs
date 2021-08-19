using System.Collections.Generic;
using System;

namespace Hotele
{
    class Program
    {
        public static void Main(string[] args)
        {
			//Lista udogodnien
			List<string> udog = new List<string>(5);
            udog.Add("Lazienka");
            udog.Add("Telewizor");
			//Tworzenie instancji pokoi
			Pokoj pokoj1 = new Pokoj("Jednoosobowy", 5, udog, 45, 1);
            Pokoj pokoj2 = new Pokoj("dwuosobowy", 2, udog, 55, 2);
			//Dodanie pokoi do listy
			List<Pokoj> pokojee = new List<Pokoj>(2);
			pokojee.Add(pokoj1);
			pokojee.Add(pokoj2);
			//Tworzenie hotelu
            Hotel hotel = new Hotel("Hotel", 4, "Opis hotelu", "Kolorow 2, Bydgoszcz", "email@email.com", pokojee);
			//Wyswietlenie pokoi dwuosobowych
            hotel.WyswietlPokojeDwuosobowe();
            //Tworzenie rezerwacji
            Rezerwacja rezerwacja1 = new Rezerwacja(3, 4, 6, new DateTime(2008, 5, 1, 8, 30, 52), new DateTime(2008, 5, 1, 8, 30, 52), 34, new DateTime(2008, 5, 1, 8, 30, 52));
           	//Tworzenie osoby
			Osoba marek = new Osoba("Marek","Nowak","email@email.com","541254874","Kolorowa 2, Bydgoszcz");
			//Tworzenie sprzedawcy
			Sprzedawca sprzedawca = new Sprzedawca("Anna","Nowak","email@email.com","541254874","Kolorowa 2, Bydgoszcz",12,"93041098837","2800",5.7,new DateTime(2008, 5, 1, 8, 30, 52));
			//Tworzenie klienta
			Klient klient = new Klient("Adam","Kowalski","email@email.pl","513457542","Pochmurna 3 Bydgoszcz",56,"Aktywny",435,"Brak uwag");
        }
    }

    //klasa Pokoj
    public class Pokoj
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaLozek { get; set; }
        public List<string> Udogodnienia { get; set; }
        public int Cena { get; set; }
        public int HotelID { get; set; }


        public Pokoj(string nazwa, int lozka, List<string> udogodnienia, int cena, int hotelID)
        {
            Random rnd = new Random();
            Id = rnd.Next(10, 99);
            Nazwa = nazwa;
            LiczbaLozek = lozka;
            Udogodnienia = udogodnienia;
            Cena = cena;
            HotelID = hotelID;

        }

        public void Wyswietl()
        {
            Console.WriteLine("-------Pokoj--------");
            Console.WriteLine("Nazwa: " + this.Nazwa);
            Console.WriteLine("Ocena: " + this.LiczbaLozek);
            Console.WriteLine("Udogodnienia: ");
            foreach (string udogodnienie in Udogodnienia)
            {
                Console.WriteLine("  " + udogodnienie);
            }
            Console.WriteLine("--------------------");
        }
    }

    //klasa Hotel
    public class Hotel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Gwiazdki { get; set; }
        public string Opis { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
		public List<Pokoj>  Pokoje {get;set;}


        public Hotel(string nazwa, int gwiazdki, string opis, string adres, string email, List<Pokoj> pokoje)
        {
            Random rnd = new Random();
            Id = rnd.Next(10, 99);
            Nazwa = nazwa;
            Gwiazdki = gwiazdki;
            Opis = opis;
            Adres = adres;
            Email = email;
            Pokoje = pokoje;
        }
		
		public void WyswietlPokojeDwuosobowe() {
			Console.WriteLine("Pokoje dwuosobowe:");
			foreach (Pokoj pokoj in Pokoje)
            {
				if(pokoj.LiczbaLozek == 2) {
					pokoj.Wyswietl();
				}
                
            }
		}

        public void Wyswietl()
        {
            Console.WriteLine("-------Hotel--------");
            Console.WriteLine("Nazwa: " + this.Nazwa);
            Console.WriteLine("Ocena: " + this.Gwiazdki);
            Console.WriteLine("Opis: " + this.Opis);
            Console.WriteLine("--------------------");
        }
    }



    //klasa Rezerwacja

    public class Rezerwacja
    {
        public int KlientID { get; set; }
        public int PokojID { get; set; }
        public int SprzedawcaID { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public int Koszt { get; set; }
        public DateTime DataSprzedazy { get; set; }


        public Rezerwacja(int klientID, int pokojID, int sprzedawcaID, DateTime dataOd, DateTime dataDo, int koszt, DateTime dataSprzedazy)
        {
            KlientID = klientID;
            PokojID = pokojID;
            SprzedawcaID = sprzedawcaID;
            DataOd = dataOd;
            DataDo = dataDo;
            Koszt = koszt;
            DataSprzedazy = dataSprzedazy;
        }

        public void Wyswietl()
        {
            Console.WriteLine("-------Rezerwacja--------");
            Console.WriteLine("Od: " + this.DataOd);
            Console.WriteLine("Do: " + this.DataDo);
            Console.WriteLine("--------------------");
        }
    }


    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }


        public Osoba(string imie, string nazwisko, string email, string telefon, string adres)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            Telefon = telefon;
            Adres = adres;
        }

        public void Wyswietl()
        {
            Console.WriteLine("-------Osoba--------");
            Console.WriteLine("Imie: " + this.Imie);
            Console.WriteLine("Nazwisko: " + this.Nazwisko);
            Console.WriteLine("--------------------");
        }
    }

    public class Sprzedawca : Osoba
    {
        public int SprzedawcaID { get; set; }
        public string Pesel { get; set; }
        public string Pensja { get; set; }

        public double Prowizja { get; set; }
        public DateTime DataUmowy { get; set; }

        public Sprzedawca(string imie, string nazwisko, string email, string telefon, string adres, int sprzedID, string pesel, string pensja, double prowizja, DateTime dataUmowy) : base(imie, nazwisko, email, telefon, adres)
        {
            SprzedawcaID = sprzedID;
            Pesel = pesel;
            Pensja = pensja;
            Prowizja = prowizja;
            DataUmowy = dataUmowy;
        }
        public new void Wyswietl()
        {
            Console.WriteLine("-------Sprzedawca--------");
            Console.WriteLine("Imie: " + this.Imie);
            Console.WriteLine("Nazwisko: " + this.Nazwisko);
            Console.WriteLine("Pensja: " + this.Prowizja);
            Console.WriteLine("--------------------");
        }


    }

    public class Klient : Osoba
    {
        public int KlientID { get; set; }
        public string Status { get; set; }
        public int Paszport { get; set; }

        public string Uwagi { get; set; }


        public Klient(string imie, string nazwisko, string email, string telefon, string adres, int klientID, string status, int paszport, string uwagi) : base(imie, nazwisko, email, telefon, adres)
        {
            KlientID = klientID;
            Status = status;
            Paszport = paszport;
            Uwagi = uwagi;

        }
        public new void Wyswietl()
        {
            Console.WriteLine("-------Klient--------");
            Console.WriteLine("Imie: " + this.Imie);
            Console.WriteLine("Nazwisko: " + this.Nazwisko);
            Console.WriteLine("Paszport: " + this.Paszport);
            Console.WriteLine("--------------------");
        }
    }
}
