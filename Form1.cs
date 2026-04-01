namespace CalculossGeometricos_WF
{
    public partial class Form1 : Form
    {
        //------------------------------------------------------------------------------------------
        //*** Proyecto (Windows Forms): Cálculos Geométricos - María Guadalupe Cabral Diaz 4 "A" ***
        //------------------------------------------------------------------------------------------
        //Declaración de variables Globales
        ComboBox cmbFiguras;
        ComboBox cmbCalculos;
        TextBox txtResultado;
        Button btnCalcular;
        Label lblCampo1;
        Label lblCampo2;
        Label lblCampo3;
        TextBox txtCampo1;
        TextBox txtCampo2;
        TextBox txtCampo3;

        public Form1()
        {
            InitializeComponent();
            InicializarComponentes();
        }
        public void InicializarComponentes()
        {
            //Para la Ventana
            this.Text = "C. G."; //'Cálculos Geométricos'
            this.Size = new Size(315, 360);
            this.StartPosition = FormStartPosition.CenterScreen; //Centrar ventana
            this.BackColor = ColorTranslator.FromHtml("#C8B3F6");

            //Etiqueta Figura
            Label lblFigura = new Label();
            lblFigura.Text = "Figura";
            lblFigura.Location = new Point(13, 13);
            lblFigura.Size = new Size(70, 25);
            lblFigura.ForeColor = Color.Blue;
            lblFigura.Font = new Font("Arial", 11, FontStyle.Bold);
            this.Controls.Add(lblFigura);

            //ComboBox Figuras
            cmbFiguras = new ComboBox();
            cmbFiguras.Items.Add("Cuadrado");
            cmbFiguras.Items.Add("Rectángulo");
            cmbFiguras.Items.Add("Triángulo");
            cmbFiguras.Items.Add("Rombo");
            cmbFiguras.Size = new Size(120, 25);
            cmbFiguras.Location = new Point(13, 40);
            this.Controls.Add(cmbFiguras);

            //Etiqueta Calculo
            Label lblCalculo = new Label();
            lblCalculo.Text = "Cálculo";
            lblCalculo.Size = new Size(80, 25);
            lblCalculo.Location = new Point(151, 15);
            lblCalculo.ForeColor = Color.Blue;
            lblCalculo.Font = new Font("Arial", 11, FontStyle.Bold);
            this.Controls.Add(lblCalculo);

            //ComboBox Calculo
            cmbCalculos = new ComboBox();
            cmbCalculos.Items.Add("Área");
            cmbCalculos.Items.Add("Perímetro");
            cmbCalculos.Size = new Size(120, 25);
            cmbCalculos.Location = new Point(150, 40);
            this.Controls.Add(cmbCalculos);

            //Botón Calcular
            btnCalcular = new Button();
            btnCalcular.Text = "Calcular";
            btnCalcular.AutoSize = true; 
            btnCalcular.Location = new Point(95, 205);
            btnCalcular.BackColor = Color.LightBlue;
            btnCalcular.ForeColor = Color.Blue;
            btnCalcular.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Controls.Add(btnCalcular);

            //Etiqueta Resultado
            Label lblResultado = new Label();
            lblResultado.Text = "Resultado:";
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(15, 260);
            lblResultado.ForeColor = Color.IndianRed;
            lblResultado.Font = new Font("Arial", 11, FontStyle.Bold);
            this.Controls.Add(lblResultado);

            //TextBox Resultado
            txtResultado = new TextBox();
            txtResultado.Size = new Size(150, 30);
            txtResultado.Location = new Point(130, 255);
            txtResultado.ReadOnly = true; //Para no modificar el TextBox 
            txtResultado.TextAlign = HorizontalAlignment.Center;
            txtResultado.Font = new Font("Franklin Gothic Demi Cond", 12);
            this.Controls.Add(txtResultado);

            //Asignar Eventos a ComboBox
            cmbFiguras.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);
            cmbCalculos.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);

            //Valores de Campos Genéricos
            //Para Label-Campos
            lblCampo1 = new Label();
            lblCampo2 = new Label();
            lblCampo3 = new Label();
            lblCampo1.Text = "1";
            lblCampo2.Text = "2";
            lblCampo3.Text = "3";
            lblCampo1.AutoSize = true;
            lblCampo2.AutoSize = true;
            lblCampo3.AutoSize = true;
            lblCampo1.Location = new Point(11, 100);
            lblCampo2.Location = new Point(11, 130);
            lblCampo3.Location = new Point(11, 160);
            lblCampo1.ForeColor = lblCampo2.ForeColor = lblCampo3.ForeColor = Color.Blue;
            lblCampo1.Font = lblCampo2.Font = lblCampo3.Font = new Font("Arial", 11, FontStyle.Bold);
            this.Controls.Add(lblCampo1);
            this.Controls.Add(lblCampo2);
            this.Controls.Add(lblCampo3);
            //Para TextBox-Campos
            txtCampo1 = new TextBox();
            txtCampo2 = new TextBox();
            txtCampo3 = new TextBox();
            txtCampo1.Size = new Size(110, 25); 
            txtCampo2.Size = new Size(110, 25); 
            txtCampo3.Size = new Size(110, 25); 
            txtCampo1.Location = new Point(132, 100);
            txtCampo2.Location = new Point(132, 130);
            txtCampo3.Location = new Point(132, 160);
            lblCampo1.Visible = false;
            lblCampo2.Visible = false;
            lblCampo3.Visible = false;
            txtCampo1.Visible = false;
            txtCampo2.Visible = false;
            txtCampo3.Visible = false;
            txtCampo1.ForeColor = txtCampo2.ForeColor = txtCampo3.ForeColor = Color.Black;
            txtCampo1.Font = txtCampo2.Font = txtCampo3.Font = new Font("Franklin Gothic Demi Cond", 10);
            txtCampo1.TextAlign = txtCampo2.TextAlign = txtCampo3.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(txtCampo1);
            this.Controls.Add(txtCampo2);
            this.Controls.Add(txtCampo3);

            //Evento Click al Botón
            btnCalcular.Click += new EventHandler(btnCalcular_Click);
        }
        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cmbCalculos.SelectedIndex != -1 && this.cmbFiguras.SelectedIndex != -1)
            {
                //ocultar y limpiar todos los campos de entrada por defecto
                lblCampo1.Visible = lblCampo2.Visible = lblCampo3.Visible = false;
                txtCampo1.Visible = txtCampo2.Visible = txtCampo3.Visible = false;
                //limpiar el contenido anterior de los cuadros de texto
                txtCampo1.Clear();
                txtCampo2.Clear();
                txtCampo3.Clear();
                switch (this.cmbFiguras.SelectedItem)
                {
                    //Caso Cuadrado
                    case "Cuadrado":
                        if(this.cmbCalculos.SelectedItem == "Perímetro")
                        {
                            lblCampo1.Text = "Lado";
                            lblCampo1.Visible = true;
                            txtCampo1.Visible = true;
                        } else
                        {
                            lblCampo1.Text = "Lado";
                            lblCampo1.Visible = true;
                            txtCampo1.Visible = true;
                        }
                        break;

                    //Caso Rectángulo
                    case "Rectángulo":
                        if (this.cmbCalculos.SelectedItem == "Perímetro")
                        {
                            lblCampo1.Text = "Base";
                            lblCampo1.Visible = true;
                            txtCampo1.Visible = true;
                            lblCampo2.Text = "Altura";
                            lblCampo2.Visible = true;
                            txtCampo2.Visible = true;
                        } else
                        {
                            lblCampo1.Text = "Base";
                            lblCampo1.Visible = true;
                            txtCampo1.Visible = true;
                            lblCampo2.Text = "Altura";
                            lblCampo2.Visible = true;
                            txtCampo2.Visible = true;
                        }
                        break;
                    
                    //Caso Triángulo
                    case "Triángulo":
                        if(this.cmbCalculos.SelectedItem == "Perímetro")
                        {
                            lblCampo1.Text = "Lado 1";
                            lblCampo2.Text = "Lado 2";
                            lblCampo3.Text = "Lado 3";
                            lblCampo1.Visible = true;
                            lblCampo2.Visible = true;
                            lblCampo3.Visible = true;
                            txtCampo1.Visible = true;
                            txtCampo2.Visible = true;
                            txtCampo3.Visible = true;

                        } else
                        {
                            lblCampo1.Text = "Base";
                            lblCampo2.Text = "Altura";
                            lblCampo1.Visible = true;
                            lblCampo2.Visible = true;
                            txtCampo1.Visible = true;
                            txtCampo2.Visible = true;
                        }
                        break;
                    
                    //Caso Rombo
                    case "Rombo":
                        if(this.cmbCalculos.SelectedItem == "Perímetro")
                        {
                            lblCampo1.Text = "Lado";
                            lblCampo1.Visible = true;
                            txtCampo1.Visible = true;
                        } else
                        {
                            lblCampo1.Text = "Diag. Mayor";
                            lblCampo2.Text = "Diag. Menor";
                            lblCampo1.Visible = true;
                            lblCampo2.Visible = true;
                            txtCampo1.Visible = true;
                            txtCampo2.Visible = true;
                        }
                        break;
                } //switch()
            } //if()
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (this.cmbCalculos.SelectedIndex != -1 && this.cmbFiguras.SelectedIndex != -1)
            {
                switch (this.cmbFiguras.SelectedItem)
                {
                    case "Cuadrado":
                        if (string.IsNullOrWhiteSpace(txtCampo1.Text))
                        {
                            //Mensaje si faltan datos en el Campo 1
                            MessageBox.Show("Complete los campos.");
                            return;
                        }

                        if (this.cmbCalculos.SelectedItem == "Perímetro")
                        {
                            double lado = double.Parse(txtCampo1.Text);
                            //Fórmula: P = 4 * lado
                            double resultado = 4 * lado;
                            txtResultado.Text = resultado.ToString();
                        }
                        else
                        {
                            double lado = double.Parse(txtCampo1.Text);
                            //Fórmula: A = lado * lado
                            double resultado = lado * lado;
                            txtResultado.Text = resultado.ToString();
                        }
                        break;

                    case "Rectángulo":
                        if (string.IsNullOrWhiteSpace(txtCampo1.Text))
                        {
                            //Mensaje si faltan datos en el Campo 1
                            MessageBox.Show("Complete los campos.");
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(txtCampo2.Text))
                        {
                            //Mensaje si faltan datos en el Campo 2
                            MessageBox.Show("Complete los campos.");
                            return;
                        }

                        if (this.cmbCalculos.SelectedItem == "Perímetro")
                        {
                            double baseR = double.Parse(txtCampo1.Text);
                            double alturaR = double.Parse(txtCampo2.Text);
                            //Fórmula: P = 2 * (base + altura)
                            double resultado = 2 * (baseR + alturaR);
                            txtResultado.Text = resultado.ToString();
                            
                        } else
                        {
                            double baseR = double.Parse(txtCampo1.Text);
                            double alturaR = double.Parse(txtCampo2.Text);
                            //Fórmula: A = base * altura
                            double resultado = baseR * alturaR;
                            txtResultado.Text = resultado.ToString();
                        }
                        break;

                    case "Triángulo":
                        if (this.cmbCalculos.SelectedItem == "Perímetro")
                        {
                            if (string.IsNullOrWhiteSpace(txtCampo1.Text))
                            {
                                //Mensaje si faltan datos en el Campo 1
                                MessageBox.Show("Complete los campos.");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(txtCampo2.Text))
                            {
                                //Mensaje si faltan datos en el Campo 2
                                MessageBox.Show("Complete los campos.");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(txtCampo3.Text))
                            {
                                //Mensaje si faltan datos en el Campo 3
                                MessageBox.Show("Complete los campos.");
                                return;
                            }
                            double l1 = double.Parse(txtCampo1.Text);
                            double l2 = double.Parse(txtCampo2.Text);
                            double l3 = double.Parse(txtCampo3.Text);
                            //Fórmula: P = lado1 + lado2 + lado3
                            double resultado = l1 + l2 + l3;
                            txtResultado.Text = resultado.ToString();
                        } else
                        {
                            if (string.IsNullOrWhiteSpace(txtCampo1.Text))
                            {
                                //Mensaje si faltan datos en el Campo 1
                                MessageBox.Show("Complete los campos.");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(txtCampo2.Text))
                            {
                                //Mensaje si faltan datos en el Campo 2
                                MessageBox.Show("Complete los campos.");
                                return;
                            }
                            double baseT = double.Parse(txtCampo1.Text);
                            double alturaT = double.Parse(txtCampo2.Text);
                            //Fórmula: A = (base * altura) / 2
                            double resultado = (baseT * alturaT) /2;
                            txtResultado.Text = resultado.ToString();
                        }
                        break;

                    case "Rombo":
                        if (this.cmbCalculos.SelectedItem == "Perímetro")
                        {
                            if (string.IsNullOrWhiteSpace(txtCampo1.Text))
                            {
                                //Mensaje si faltan datos en el Campo 1
                                MessageBox.Show("Complete los campos.");
                                return;
                            }
                            double lado = double.Parse(txtCampo1.Text);
                            //Fórmula: P = 4 * lado
                            double resultado = 4 * lado;
                            txtResultado.Text = resultado.ToString();
                        } else
                        {
                            if (string.IsNullOrWhiteSpace(txtCampo1.Text))
                            {
                                //Mensaje si faltan datos en el Campo 1
                                MessageBox.Show("Complete los campos.");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(txtCampo2.Text))
                            {
                                //Mensaje si faltan datos en el Campo 2
                                MessageBox.Show("Complete los campos.");
                                return;
                            }
                            double dMayor = double.Parse(txtCampo1.Text);
                            double dMenor = double.Parse(txtCampo2.Text);
                            // Fórmula: A = (Diagonal Mayor * Diagonal Menor) / 2
                            double resultado = (dMayor * dMenor) / 2;
                            txtResultado.Text = resultado.ToString();
                        }
                        break;
                } //Fin_switch()
            } //Fin_if(cmbCalculos.SelectedIndex)
        }

    }
}