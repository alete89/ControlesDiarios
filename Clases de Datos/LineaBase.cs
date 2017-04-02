namespace Controles2016
{
    public class LineaBase
    {
        public decimal central = 112.15m;
        public decimal planicidadArribaAbajo = 4.06m;
        public decimal planicidadIzquierdaDerecha = 0.86m;
        public decimal simetriaArribaAbajo = 4.03m;
        public decimal simetriaIzquierdaDerecha = 0.78m;
    }
}

/*TO DO:
 * un archivo diferente para guardar la línea base? así lo puedo actualizar.
 * copiar el método de el registro.
 * 
 *             IOarchivos.WriteJson(@".\LB.bin", this);
 * 
 * 
 * 
 *         public decimal central = 112.149987706229;
        public decimal planicidadArribaAbajo = 4.06428321331292;
        public decimal planicidadIzquierdaDerecha = 0.857586121479557;
        public decimal simetriaArribaAbajo = 4.03450598898689;
        public decimal simetriaIzquierdaDerecha = 0.77561827637615;
*/
