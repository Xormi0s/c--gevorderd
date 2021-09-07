using System;
using System.Collections.Generic;
using System.Text;

namespace Les4Oefening
{

    public enum ProviderStatus
    {
        Online,
        Offline,
        Restricted
    }
    class Provider
    {
        private string naam = "";
        private int connectiesnelheid;
        private List<Smartphone> smartphones = new List<Smartphone>();
        private ProviderStatus status;

        public Provider()
        {
            this.status = ProviderStatus.Offline;
        }
        public Provider(string naam, int snelheid)
        {
            this.naam = naam;
            this.ConnectieSnelheid = snelheid;
            this.status = ProviderStatus.Offline;
        }

        public string Naam
        {
            get
            {
                return this.naam;
            }
            set
            {
                this.naam = value;
            }
        }

        public int ConnectieSnelheid
        {
            get 
            { 
                return this.connectiesnelheid; 
            }
            set 
            { 
                this.connectiesnelheid = value; 
            }
        }

        public List<Smartphone> Smartphones
        {
            get
            {
                return this.smartphones;
            }
            set
            {
                this.smartphones = value;
            }
        }

        public ProviderStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public void VoegSmartphoneToe(ref Smartphone smartphone)
        {
            if (status == ProviderStatus.Online)
            {
                if (smartphone.Verbind(connectiesnelheid) == false)
                {
                    throw new Exception("Apparaat niet compatibel");
                } else
                {
                    smartphones.Add(smartphone);
                }
            } else
            {
                throw new Exception("Netwerk is niet online");
            }
        }
    }
}
