using System;

namespace Controles2016
{
    [Serializable]
    public class Registro
    {
        public string _fecha { get; set; }
        //public int _idRegistro  { get; set; }
        public string _realizo { get; set; }
        public string _nivelAgua { get; set; }
        public string _presionAgua { get; set; }
        public string _temperaturaAgua { get; set; }
        public string _presionGas { get; set; }
        public string _temperaturaChiller { get; set; }
        public string _comentario { get; set; }
        public decimal _lecturaPresion { get; set; }
        public decimal _lecturaTemperatura { get; set; }
        public decimal _lecturaCentral { get; set; }
        public decimal _lecturaArriba { get; set; }
        public decimal _lecturaAbajo { get; set; }
        public decimal _lecturaIzquierda { get; set; }
        public decimal _lecturaDerecha { get; set; }
        public decimal _lecturaCentralCorregida { get; set; }
        public decimal _lecturaCentralLineaBase { get; set; }
        public decimal _simetriaArribaAbajo { get; set; }
        public decimal _simetriaArribaAbajoLineaBase { get; set; }
        public decimal _simetriaIzquierdaDerecha { get; set; }
        public decimal _simetriaIzquierdaDerechaLineaBase { get; set; }
        public decimal _planicidadIzquierdaDerecha { get; set; }
        public decimal _planicidadArribaAbajo { get; set; }
        public decimal _planicidadArribaAbajoLineaBase { get; set; }
        public decimal _planicidadIzquierdaDerechaLineaBase { get; set; }
        public bool _laser { get; set; }
        public bool _distancia { get; set; }
        public bool _cincox { get; set; }
        public bool _diezx { get; set; }
        public bool _veinticincox { get; set; }
        public bool _mlc { get; set; }
        public bool _switchPuerta { get; set; }
        public bool _lucesPuerta { get; set; }
        public bool _luzConsola { get; set; }
        public bool _apagadoEmergencia { get; set; }

        public void addRegistro(string fecha,
            //int idRegistro,
                        string realizo,
                        string nivelAgua,
                        string presionAgua,
                        string temperaturaAgua,
                        string presionGas,
                        string temperaturaChiller,
                        string comentario,
                        decimal lecturaPresion,
                        decimal lecturaTemperatura,
                        decimal lecturaCentral,
                        decimal lecturaArriba,
                        decimal lecturaAbajo,
                        decimal lecturaIzquierda,
                        decimal lecturaDerecha,
                        decimal lecturaCentralCorregida,
                        decimal lecturaCentralLineaBase,
                        decimal simetriaArribaAbajo,
                        decimal simetriaArribaAbajoLineaBase,
                        decimal simetriaIzquierdaDerecha,
                        decimal simetriaIzquierdaDerechaLineaBase,
                        decimal planicidadIzquierdaDerecha,
                        decimal planicidadArribaAbajo,
                        decimal planicidadArribaAbajoLineaBase,
                        decimal planicidadIzquierdaDerechaLineaBase,
                        bool laser,
                        bool distancia,
                        bool cincox,
                        bool diezx,
                        bool veinticincox,
                        bool mlc,
                        bool switchPuerta,
                        bool lucesPuerta,
                        bool luzConsola,
                        bool apagadoEmergencia)
        {
            this._fecha = fecha;
            this._realizo = realizo;
            this._nivelAgua = nivelAgua;
            this._presionAgua = presionAgua;
            this._temperaturaAgua = temperaturaAgua;
            this._presionGas = presionGas;
            this._temperaturaChiller = temperaturaChiller;
            this._comentario = comentario;
            this._lecturaPresion = lecturaPresion;
            this._lecturaTemperatura = lecturaTemperatura;
            this._lecturaCentral = lecturaCentral;
            this._lecturaArriba = lecturaArriba;
            this._lecturaAbajo = lecturaAbajo;
            this._lecturaIzquierda = lecturaIzquierda;
            this._lecturaDerecha = lecturaDerecha;
            this._lecturaCentralCorregida = lecturaCentralCorregida;
            this._lecturaCentralLineaBase = lecturaCentralLineaBase;
            this._simetriaArribaAbajo = simetriaArribaAbajo;
            this._simetriaArribaAbajoLineaBase = simetriaArribaAbajoLineaBase;
            this._simetriaIzquierdaDerecha = simetriaIzquierdaDerecha;
            this._simetriaIzquierdaDerechaLineaBase = simetriaIzquierdaDerechaLineaBase;
            this._planicidadArribaAbajo = planicidadArribaAbajo;
            this._planicidadArribaAbajoLineaBase = planicidadArribaAbajoLineaBase;
            this._planicidadIzquierdaDerecha = planicidadIzquierdaDerecha;
            this._planicidadIzquierdaDerechaLineaBase = planicidadIzquierdaDerechaLineaBase;
            this._laser = laser;
            this._distancia = distancia;
            this._cincox = cincox;
            this._diezx = diezx;
            this._veinticincox = veinticincox;
            this._mlc = mlc;
            this._switchPuerta = switchPuerta;
            this._lucesPuerta = lucesPuerta;
            this._luzConsola = luzConsola;
            this._apagadoEmergencia = apagadoEmergencia;
        }

    }
}
