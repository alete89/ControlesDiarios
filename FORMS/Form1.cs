using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace Controles2016
{
    public partial class Form1 : Form
    {
        const string file = @".\REGISTROS.bin";
        public static LineaBase lb = new LineaBase();
        Registro newRegistro = new Registro();
        
        LineaBaseEdit form2 = new LineaBaseEdit();

        public static Form1 instancia = null;

        List<Registro> lista = new List<Registro>();

        //declarar en 0 algunas variables
        decimal lecturaTemperatura = 0;
        decimal lecturaPresion = 0;
        decimal lecturaCentral = 0;
        decimal lecturaAbajo = 0;
        decimal lecturaArriba = 0;
        decimal lecturaIzquierda = 0;
        decimal lecturaDerecha = 0;
        decimal lecturaCentralCorregida = 0;
        decimal lecturaCentralLineaBase = 0;
        decimal simetriaArribaAbajo = 0;
        decimal simetriaArribaAbajoLineaBase = 0;
        decimal simetriaIzquierdaDerecha = 0;
        decimal simetriaIzquierdaDerechaLineaBase = 0;
        decimal planicidadIzquierdaDerecha = 0;
        decimal planicidadArribaAbajo = 0;
        decimal planicidadArribaAbajoLineaBase = 0;
        decimal planicidadIzquierdaDerechaLineaBase = 0;
        bool laser = false;
        bool distancia = false;
        bool cincox = false;
        bool diezx = false;
        bool veinticincox = false;
        bool mlc = false;
        bool switchPuerta = false;
        bool lucesPuerta = false;
        bool luzConsola = false;
        bool apagadoEmergencia = false;

        public Form1()
        {

            InitializeComponent();
        }

        #region eventos FORM enter leave y focus select
        public void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@".\LB.bin"))
            {
                lb = JsonConvert.DeserializeObject<LineaBase>(File.ReadAllText(@".\LB.bin"));
            }
            else
            {
                IOarchivos.WriteJson(@".\LB.bin", lb);
                MessageBox.Show("Bienvenido por primera vez!\nSe generó una nueva línea base precargada.");
            }

                HOY.Text = DateTime.Now.ToShortDateString();

            try
            {
                //lista = ReadFromBinaryFile<<Registro>>(file);
                lista = IOarchivos.ReadJsonList<Registro>(file);
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LecturaArriba_Leave(object sender, EventArgs e)
        {
            try
            {
                if (LecturaArriba.Text.Length == 0)
                {
                    LecturaArriba.Text = "Lectura Arriba";
                    LecturaArriba.ForeColor = SystemColors.GrayText;
                }
                else
                {
                    lecturaArriba = decimal.Parse(LecturaArriba.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" La lectura debe ser un número");
                //throw;
            }
        }

        private void LecturaArriba_Enter(object sender, EventArgs e)
        {
            if (LecturaArriba.Text == "Lectura Arriba")
            {
                LecturaArriba.Text = "";
                LecturaArriba.ForeColor = SystemColors.WindowText;
            }
            else
            {
                LecturaArriba.SelectAll();
            }
        }

        private void LecturaAbajo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (LecturaAbajo.Text.Length == 0)
                {
                    LecturaAbajo.Text = "Lectura Abajo";
                    LecturaAbajo.ForeColor = SystemColors.GrayText;
                }
                else
                {
                    lecturaAbajo = decimal.Parse(LecturaAbajo.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" La lectura debe ser un número");
                //throw;
            }
        }

        private void LecturaAbajo_Enter(object sender, EventArgs e)
        {
            if (LecturaAbajo.Text == "Lectura Abajo")
            {
                LecturaAbajo.Text = "";
                LecturaAbajo.ForeColor = SystemColors.WindowText;
            }
            else
            {
                LecturaAbajo.SelectAll();
            }
        }

        private void LecturaDerecha_Leave(object sender, EventArgs e)
        {
            try
            {
                if (LecturaDerecha.Text.Length == 0)
                {
                    LecturaDerecha.Text = "Lectura Derecha";
                    LecturaDerecha.ForeColor = SystemColors.GrayText;
                }
                else
                {
                    lecturaDerecha = decimal.Parse(LecturaDerecha.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" La lectura debe ser un número");
                //throw;
            }
        }

        private void LecturaDerecha_Enter(object sender, EventArgs e)
        {
            if (LecturaDerecha.Text == "Lectura Derecha")
            {
                LecturaDerecha.Text = "";
                LecturaDerecha.ForeColor = SystemColors.WindowText;
            }
            else
            {
                LecturaDerecha.SelectAll();
            }
        }

        private void LecturaIzquierda_Leave(object sender, EventArgs e)
        {
            try
            {
                if (LecturaIzquierda.Text.Length == 0)
                {
                    LecturaIzquierda.Text = "Lectura Izquierda";
                    LecturaIzquierda.ForeColor = SystemColors.GrayText;
                }
                else
                {
                    lecturaIzquierda = decimal.Parse(LecturaIzquierda.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" La lectura debe ser un número");
                //throw;
            }
        }

        private void LecturaIzquierda_Enter(object sender, EventArgs e)
        {
            if (LecturaIzquierda.Text == "Lectura Izquierda")
            {
                LecturaIzquierda.Text = "";
                LecturaIzquierda.ForeColor = SystemColors.WindowText;
            }
            else
            {
                LecturaIzquierda.SelectAll();
            }
        }

        private void LecturaCentro_Leave(object sender, EventArgs e)
        {
            if (LecturaCentro.Text.Length == 0)
            {
                LecturaCentro.Text = "Lectura Central";
                LecturaCentro.ForeColor = SystemColors.GrayText;
            }
            else
            {
                try
                {
                    lecturaCentral = decimal.Parse(LecturaCentro.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(" La lectura debe ser un número");
                    //throw;
                }
            }
        }

        private void LecturaCentro_Enter(object sender, EventArgs e)
        {
            if (LecturaCentro.Text == "Lectura Central")
            {
                LecturaCentro.Text = "";
                LecturaCentro.ForeColor = SystemColors.WindowText;
            }
            else
            {
                LecturaCentro.SelectAll();
            }
        }

        public void LecturaTemp_Leave(object sender, EventArgs e)
        {
            if (LecturaTemp.Text.Length != 0)
            {
                try
                {
                    lecturaTemperatura = decimal.Parse(LecturaTemp.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(" La temperatura debe ser un número");
                    //throw;
                }
            }
        }

        private void LecturaPresion_Leave(object sender, EventArgs e)
        {
            if (LecturaPresion.Text.Length != 0)
            {
                try
                {
                    lecturaPresion = decimal.Parse(LecturaPresion.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(" La presión debe ser un número");
                    //throw;
                }
            }
        }

        // SELECT ON FOCUS

        private void PresionAgua_Focus(object sender, EventArgs e)
        {
            PresionAgua.SelectAll();
        }

        private void TemperaturaAgua_Focus(object sender, EventArgs e)
        {
            TemperaturaAgua.SelectAll();
        }

        private void PresionGas_Focus(object sender, EventArgs e)
        {
            PresionGas.SelectAll();
        }

        private void TemperaturaChiller_Focus(object sender, EventArgs e)
        {
            TemperaturaChiller.SelectAll();
        }

        private void lecturaPresion_Focus(object sender, EventArgs e)
        {
            LecturaPresion.SelectAll();
        }

        private void lecturaTemperatura_Focus(object sender, EventArgs e)
        {
            LecturaTemp.SelectAll();
        }

        #endregion


        private void botonRegistro_Click(object sender, EventArgs e)
        {
            bool valorSinCompletar = false;
            if (LecturaArriba.Text == "Lectura Arriba") valorSinCompletar = true;
            if (LecturaAbajo.Text == "Lectura Abajo") valorSinCompletar = true;
            if (LecturaIzquierda.Text == "Lectura Izquierda") valorSinCompletar = true;
            if (LecturaDerecha.Text == "Lectura Derecha") valorSinCompletar = true;
            if (LecturaCentro.Text == "Lectura Central") valorSinCompletar = true;
            if (LecturaPresion.Text == "") valorSinCompletar = true;
            if (LecturaTemp.Text == "") valorSinCompletar = true;

            //mecánicos
            if (!LaserOK.Checked && !LaserERROR.Checked) valorSinCompletar = true;
            if (!DistOK.Checked && !DistERROR.Checked) valorSinCompletar = true;
            if (!Campo5x5OK.Checked && !Campo5x5ERROR.Checked) valorSinCompletar = true;
            if (!Campo10x10OK.Checked && !Campo10x10ERROR.Checked) valorSinCompletar = true;
            if (!Campo25x25OK.Checked && !Campo25x25ERROR.Checked) valorSinCompletar = true;
            if (!MLCOK.Checked && !MLCERROR.Checked) valorSinCompletar = true;
            //seguridad
            if (!SwitchOK.Checked && !SwitchERROR.Checked) valorSinCompletar = true;
            if (!LucesOK.Checked && !LucesERROR.Checked) valorSinCompletar = true;
            if (!IndicadorRadOK.Checked && !IndicadorRadERROR.Checked) valorSinCompletar = true;
            if (!EmergenciaOK.Checked && !EmergenciaERROR.Checked) valorSinCompletar = true;

            if (PresionAgua.Text == "") valorSinCompletar = true;
            if (!rbNivelAgua1.Checked && !rbNivelAgua2.Checked && !rbNivelAgua3.Checked && !rbNivelAgua4.Checked && !rbNivelAgua5.Checked) valorSinCompletar = true;
            if (TemperaturaAgua.Text == "") valorSinCompletar = true;
            if (PresionGas.Text == "") valorSinCompletar = true;
            if (TemperaturaChiller.Text == "") valorSinCompletar = true;
            if (Responsable.Text == "") valorSinCompletar = true;
            if (valorSinCompletar)
            {
                DialogResult dialog = MessageBox.Show("Algún campo quedó sin completar. ¿Desea registrar de todos modos?", "Alerta", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    #region ASIGNACION AL OBJETO REGISTRO
                    try
                    {
                        string fecha;
                        if (!dateTimePicker1.Enabled)
                        {
                            fecha = DateTime.Now.Date.ToShortDateString();
                        }
                        else
                        {
                            fecha = dateTimePicker1.Value.Date.ToShortDateString();
                        }


                        //mecánicos
                        if (LaserOK.Checked) { laser = true; }
                        if (LaserERROR.Checked) { laser = false; }
                        if (DistOK.Checked) { distancia = true; }
                        if (DistERROR.Checked) { distancia = false; }
                        if (Campo5x5OK.Checked) { cincox = true; }
                        if (Campo5x5ERROR.Checked) { cincox = false; }
                        if (Campo10x10OK.Checked) { diezx = true; }
                        if (Campo10x10ERROR.Checked) { diezx = false; }
                        if (Campo25x25OK.Checked) { veinticincox = true; }
                        if (Campo25x25ERROR.Checked) { veinticincox = false; }
                        if (MLCOK.Checked) { mlc = true; }
                        if (MLCERROR.Checked) { mlc = false; }
                        //seguridad
                        if (SwitchOK.Checked) { switchPuerta = true; }
                        if (SwitchERROR.Checked) { switchPuerta = false; }
                        if (LucesOK.Checked) { lucesPuerta = true; }
                        if (LucesERROR.Checked) { lucesPuerta = false; }
                        if (IndicadorRadOK.Checked) { luzConsola = true; }
                        if (IndicadorRadERROR.Checked) { luzConsola = false; }
                        if (EmergenciaOK.Checked) { apagadoEmergencia = true; }
                        if (EmergenciaERROR.Checked) { apagadoEmergencia = false; }
                        //equipo

                        string nivelAgua = "";
                        if (rbNivelAgua1.Checked) nivelAgua = "<min";
                        if (rbNivelAgua2.Checked) nivelAgua = "min";
                        if (rbNivelAgua3.Checked) nivelAgua = "opt";
                        if (rbNivelAgua4.Checked) nivelAgua = "max";
                        if (rbNivelAgua5.Checked) nivelAgua = ">max";
                        string presionAgua = PresionAgua.Text;
                        string temperaturaAgua = TemperaturaAgua.Text;
                        string presionGas = PresionGas.Text;
                        string temperaturaChiller = TemperaturaChiller.Text;
                        //responsable
                        string realizo = Responsable.Text;

                        //observación
                        string comentario;
                        if (obsBox.Text == "Escriba aquí cualquier comentario adicional respecto a ese control.") { comentario = ""; } else { comentario = obsBox.Text; }

                        //fin del formulario
                        newRegistro.addRegistro(fecha, realizo, nivelAgua, presionAgua, temperaturaAgua, presionGas, temperaturaChiller, comentario, lecturaPresion, lecturaTemperatura, lecturaCentral, lecturaArriba, lecturaAbajo, lecturaIzquierda, lecturaDerecha, lecturaCentralCorregida, lecturaCentralLineaBase, simetriaArribaAbajo, simetriaArribaAbajoLineaBase, simetriaIzquierdaDerecha, simetriaIzquierdaDerechaLineaBase, planicidadIzquierdaDerecha, planicidadArribaAbajo, planicidadArribaAbajoLineaBase, planicidadIzquierdaDerechaLineaBase, laser, distancia, cincox, diezx, veinticincox, mlc, switchPuerta, lucesPuerta, luzConsola, apagadoEmergencia);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ocurrió algún error en la asignación al objeto Registro");
                        MessageBox.Show(ex.ToString());
                    }
                    #endregion

                    //leer la lista actual
                    //try { lista = ReadFromBinaryFile<List<Registro>>(file); }
                    try
                    {
                        lista = IOarchivos.ReadJsonList<Registro>(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("se intentó leer si hay un diccionario antes que nada, hubo un error. Si no existía, se creó y guardó el registro " + ex.ToString());
                    }
                    try
                    {
                        //agrego el newRegistro a la lista
                        lista.Add(newRegistro);

                        //escribo en archivo la lista actual
                        WriteToBinaryFile(file, lista);
                        IOarchivos.WriteJson(file, lista);

                        //mostrar que se registró
                        timerRegistro.Enabled = true;
                        RegistradoOK.Visible = true;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("ocurrió un error al cargar el nuevo registro al diccionario, o al escribir el diccionario en el archivo " + ex.ToString());
                    }
                }
                if (dialog == DialogResult.No)
                {

                }
            }
            else
            {
                #region ASIGNACION AL OBJETO REGISTRO
                try
                {
                    string fecha;
                    if (!dateTimePicker1.Enabled)
                    {
                        fecha = DateTime.Now.Date.ToShortDateString();
                    }
                    else
                    {
                        fecha = dateTimePicker1.Value.Date.ToShortDateString();
                    }


                    //mecánicos
                    if (LaserOK.Checked) { laser = true; }
                    if (LaserERROR.Checked) { laser = false; }
                    if (DistOK.Checked) { distancia = true; }
                    if (DistERROR.Checked) { distancia = false; }
                    if (Campo5x5OK.Checked) { cincox = true; }
                    if (Campo5x5ERROR.Checked) { cincox = false; }
                    if (Campo10x10OK.Checked) { diezx = true; }
                    if (Campo10x10ERROR.Checked) { diezx = false; }
                    if (Campo25x25OK.Checked) { veinticincox = true; }
                    if (Campo25x25ERROR.Checked) { veinticincox = false; }
                    if (MLCOK.Checked) { mlc = true; }
                    if (MLCERROR.Checked) { mlc = false; }
                    //seguridad
                    if (SwitchOK.Checked) { switchPuerta = true; }
                    if (SwitchERROR.Checked) { switchPuerta = false; }
                    if (LucesOK.Checked) { lucesPuerta = true; }
                    if (LucesERROR.Checked) { lucesPuerta = false; }
                    if (IndicadorRadOK.Checked) { luzConsola = true; }
                    if (IndicadorRadERROR.Checked) { luzConsola = false; }
                    if (EmergenciaOK.Checked) { apagadoEmergencia = true; }
                    if (EmergenciaERROR.Checked) { apagadoEmergencia = false; }
                    //equipo
                    string nivelAgua = "";
                    if (rbNivelAgua1.Checked) nivelAgua = "<min";
                    if (rbNivelAgua2.Checked) nivelAgua = "min";
                    if (rbNivelAgua3.Checked) nivelAgua = "opt";
                    if (rbNivelAgua4.Checked) nivelAgua = "max";
                    if (rbNivelAgua5.Checked) nivelAgua = ">max";
                    string presionAgua = PresionAgua.Text;
                    string temperaturaAgua = TemperaturaAgua.Text;
                    string presionGas = PresionGas.Text;
                    string temperaturaChiller = TemperaturaChiller.Text;
                    //responsable
                    string realizo = Responsable.Text;

                    //observación
                    string comentario;
                    if (obsBox.Text == "Escriba aquí cualquier comentario adicional respecto a ese control.") { comentario = ""; } else { comentario = obsBox.Text; }

                    //fin del formulario
                    newRegistro.addRegistro(fecha, realizo, nivelAgua, presionAgua, temperaturaAgua, presionGas, temperaturaChiller, comentario, lecturaPresion, lecturaTemperatura, lecturaCentral, lecturaArriba, lecturaAbajo, lecturaIzquierda, lecturaDerecha, lecturaCentralCorregida, lecturaCentralLineaBase, simetriaArribaAbajo, simetriaArribaAbajoLineaBase, simetriaIzquierdaDerecha, simetriaIzquierdaDerechaLineaBase, planicidadIzquierdaDerecha, planicidadArribaAbajo, planicidadArribaAbajoLineaBase, planicidadIzquierdaDerechaLineaBase, laser, distancia, cincox, diezx, veinticincox, mlc, switchPuerta, lucesPuerta, luzConsola, apagadoEmergencia);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ocurrió algún error en la asignación al objeto Registro");
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                //leer la lista actual
                //try { lista = ReadFromBinaryFile<List<Registro>>(file); }
                try
                {
                    lista = IOarchivos.ReadJsonList<Registro>(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("se intentó leer si hay un diccionario antes que nada, hubo un error. Si no existía, se creó y guardó el registro " + ex.ToString());
                }
                try
                {
                    //agrego el newRegistro a la lista
                    lista.Add(newRegistro);

                    //escribo en archivo la lista actual
                    WriteToBinaryFile(file, lista);
                    IOarchivos.WriteJson(file, lista);

                    //mostrar que se registró
                    timerRegistro.Enabled = true;
                    RegistradoOK.Visible = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ocurrió un error al cargar el nuevo registro al diccionario, o al escribir el diccionario en el archivo " + ex.ToString());
                }

            }
        }


        #region update alertas
        public void updateAlertaCentral()
        {
            //REGISTRO
            try
            {
                lecturaCentralCorregida = (273.20m + lecturaTemperatura) / 293.2m * 1013 / lecturaPresion * lecturaCentral;
                lecturaCentralLineaBase = (lecturaCentralCorregida - lb.central) / lb.central * 100;
            }
            catch (Exception)
            {

                //throw;
            }
            //ALERTAS
            if (Math.Abs(lecturaCentralLineaBase) > 3)
            {
                LabelAlertaCentral.Visible = true;
            }
            else
            {
                LabelAlertaCentral.Visible = false;
            }
        }

        private void updateAlertaPlanicidadY()
        {
            try
            {
                planicidadArribaAbajo = (Math.Max(lecturaAbajo, Math.Max(lecturaCentral, lecturaArriba)) - Math.Min(lecturaAbajo, Math.Min(lecturaCentral, lecturaArriba))) / promedio(lecturaAbajo, lecturaCentral, lecturaArriba) * 100;
                planicidadArribaAbajoLineaBase = planicidadArribaAbajo - lb.planicidadArribaAbajo;
            }
            catch (Exception)
            {

                //throw;
            }
            if (planicidadArribaAbajoLineaBase > 2)
            {
                LabelPlanicidadY.Visible = true;
            }
            else { LabelPlanicidadY.Visible = false; }
        }

        public void updateAlertaPlanicidadX()
        {
            try
            {
                planicidadIzquierdaDerecha = (Math.Max(lecturaIzquierda, Math.Max(lecturaCentral, lecturaDerecha)) - Math.Min(lecturaIzquierda, Math.Min(lecturaCentral, lecturaDerecha))) / promedio(lecturaIzquierda, lecturaCentral, lecturaDerecha) * 100;
                planicidadIzquierdaDerechaLineaBase = planicidadIzquierdaDerecha - lb.planicidadIzquierdaDerecha;
            }
            catch (Exception)
            {

               // throw;
            }
            if (planicidadIzquierdaDerechaLineaBase > 2)
            {
                LabelPlanicidadX.Visible = true;
            }
            else { LabelPlanicidadX.Visible = false; }
        }

        private void updateAlertaSimetriaX()
        {
            try
            {
                simetriaIzquierdaDerecha = Math.Abs(lecturaDerecha - lecturaIzquierda) / lecturaCentral * 100;
                simetriaIzquierdaDerechaLineaBase = simetriaIzquierdaDerecha - lb.simetriaIzquierdaDerecha;
            }
            catch (Exception)
            {

                //throw;
            }
            if (simetriaIzquierdaDerechaLineaBase > 2)
            {
                LabelSimetriaX.Visible = true;
            }
            else { LabelSimetriaX.Visible = false; }
        }

        private void updateAlertaSimetriaY()
        {
            try
            {
                simetriaArribaAbajo = Math.Abs(lecturaArriba - lecturaAbajo) / lecturaCentral * 100;
                simetriaArribaAbajoLineaBase = simetriaArribaAbajo - lb.simetriaArribaAbajo;
            }
            catch (Exception)
            {

                //throw;
            }
            if (simetriaArribaAbajoLineaBase > 2)
            {
                LabelSimetriaY.Visible = true;
            }
            else { LabelSimetriaY.Visible = false; }
        }
        #endregion

        #region métodos anexos UI form
        public decimal promedio(decimal a, decimal b, decimal c)
        {

            decimal suma = a + b + c;
            decimal promedio = suma / 3;
            return promedio;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateAlertaCentral();
            updateAlertaPlanicidadX();
            updateAlertaPlanicidadY();
            updateAlertaSimetriaX();
            updateAlertaSimetriaY();
        }

        private void timerRegistro_Tick(object sender, EventArgs e)
        {
            RegistradoOK.Visible = false;
        }
        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                instancia = this;
                form2.Show();

            }
            else //uncheck
            {
                if (form2 != null)
                    form2.Hide();
            }
        }

        public void cambiarcheck()
        {
            checkBox1.Checked = !checkBox1.Checked;
        }

        private void obsBox_Enter(object sender, EventArgs e)
        {
            if (obsBox.Text == "Escriba aquí cualquier comentario adicional respecto a ese control.")
            {
                obsBox.Text = "";
                obsBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void obsBox_Leave(object sender, EventArgs e)
        {
            if (obsBox.Text.Length == 0)
            {
                obsBox.Text = "Escriba aquí cualquier comentario adicional respecto a ese control.";
                obsBox.ForeColor = SystemColors.GrayText;
            }
        }
        #endregion

        #region métodos anexos escribir y leer de archivo
        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
        #endregion

        private void btnReport_Click(object sender, EventArgs e)
        {
            PasswordForm pf = new PasswordForm();
            pf.ShowDialog();
            this.SendToBack();
        }

        private void chkOtraFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Enabled)
            {
                dateTimePicker1.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LecturaAbajo.Text = "";
            LecturaIzquierda.Text = "";
            LecturaDerecha.Text = "";
            LecturaArriba.Text = "";
            LecturaCentro.Text = "";
            LecturaArriba_Leave(this, EventArgs.Empty);
            LecturaAbajo_Leave(this, EventArgs.Empty);
            LecturaIzquierda_Leave(this, EventArgs.Empty);
            LecturaDerecha_Leave(this, EventArgs.Empty);
            LecturaCentro_Leave(this, EventArgs.Empty);
            LecturaPresion.Text = "";
            LecturaTemp.Text = "";
            obsBox.Text = "";
            obsBox_Leave(this, EventArgs.Empty);
            rbNivelAgua1.Checked = false;
            rbNivelAgua2.Checked = false;
            rbNivelAgua3.Checked = false;
            rbNivelAgua4.Checked = false;
            rbNivelAgua5.Checked = false;
            PresionAgua.Text = "";
            TemperaturaAgua.Text = "";
            PresionGas.Text = "";
            TemperaturaChiller.Text = "";
            Responsable.Text = "";
            if (chkOtraFecha.Checked==true)
            {
                chkOtraFecha.Checked = false;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker1.Enabled = false;
                
            }
            LaserOK.Checked = false;
            LaserERROR.Checked = false;
            DistOK.Checked = false;
            DistERROR.Checked = false;
            Campo10x10OK.Checked = false;
            Campo10x10ERROR.Checked = false;
            Campo5x5OK.Checked = false;
            Campo5x5ERROR.Checked = false;
            Campo25x25OK.Checked = false;
            Campo25x25ERROR.Checked = false;
            MLCOK.Checked = false;
            MLCERROR.Checked = false;

            SwitchOK.Checked = false;
            SwitchERROR.Checked = false;
            LucesOK.Checked = false;
            LucesERROR.Checked = false;
            IndicadorRadOK.Checked = false;
            IndicadorRadERROR.Checked = false;
            EmergenciaOK.Checked = false;
            EmergenciaERROR.Checked = false;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }
    }
}
