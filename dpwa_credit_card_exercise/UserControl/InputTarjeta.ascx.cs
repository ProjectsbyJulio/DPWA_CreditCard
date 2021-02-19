using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dpwa_credit_card_exercise
{
    public partial class InputText : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                fillMonths();
                fillYears();
            }
            else
            {
                fillMonths();
                fillYears();
            }
        }

        protected void fillMonths()
        {
            for (int i = 0; i < 12; i++)
            {
                drpMes.Items.Add($"{i + 1}");
            }
        }

        protected void fillYears()
        {
            string date;
            for (int i = 0; i < 30; i++)
            {
                date = DateTime.Now.AddYears(i).ToString("yyyy");
                drpYear.Items.Add(date);
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            validarTarjeta();
        }

        protected void validarTarjeta()
        {
            string actualNum = this.txtTarjeta.Text;
            string nuevoNum = "";
            string valor;
            if (actualNum.Length < 16)
            {
                lblResponse.Text = "<p class=text-danger>Ingresa un número de tarjeta de crédito</p>";
                dangerBorder();
            }
            else
            {
                for (int i = 0; i < actualNum.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        valor = actualNum.Substring(i, 1);
                        if ((Convert.ToInt32(valor) * 2) < 9)
                        {
                            valor = (Convert.ToInt32(valor) * 2).ToString();
                        }
                        else
                        {
                            valor = ((Convert.ToInt32(valor) * 2) - 9).ToString();
                        }
                    }
                    else
                    {
                        valor = actualNum.Substring(i, 1);
                    }
                    nuevoNum += valor;
                }
                int suma = 0;
                for (int i = 0; i < nuevoNum.Length; i++)
                {
                    suma += Convert.ToInt32(nuevoNum.Substring(i, 1));
                }
                if (suma % 10 == 0 && suma <= 150)
                {
                    if (identificarMarca() && validarFecha())
                    {
                        lblResponse.Text = "<p class=text-success>Número de tarjeta válido</p>";
                        successBorder();
                    }else{
                        lblResponse2.Text = " ";
                        lblResponse.Text = "<p class=text-danger>Número de tarjeta inválido</p>";
                        dangerBorder();
                    }

                }
                else
                {
                    //Numero inválido
                    validarFecha();
                    lblResponse.Text = "<p class=text-danger>Número de tarjeta inválido</p>";
                    dangerBorder();
                }
            }
        }

        protected bool identificarMarca()
        {
            try
            {
                int firstCardNumber = Convert.ToInt32(txtTarjeta.Text.Substring(0, 1));
                switch (firstCardNumber)
                {
                    case 3:
                        lblResponse2.Text = "<p class=text-success>La tarjeta es American Express</p>";
                        return true;
                    case 4:
                        lblResponse2.Text = "<p class=text-success>La tarjeta es Visa</p>";
                        return true;
                    case 5:
                        lblResponse2.Text = "<p class=text-success>La tarjeta es MasterCard</p>";
                        return true;
                    case 6:
                        lblResponse2.Text = "<p class=text-success>La tarjeta es Discover</p>";
                        return true;
                    default:
                        lblResponse2.Text = "<p class=text-danger>Has ingresado un número de tarjeta que no pertenece a ningún proveedor válido</p>";
                        return false;
                }
            }
            catch (Exception)
            {
                lblResponse2.Text = "<p class=text-danger>Has ingresado un número de tarjeta que no pertenece a ningún proveedor válido</p>";
                dangerBorder();
                return false;
            }
        }

        protected bool validarFecha()
        {
            int actualMonth = DateTime.Now.Month;
            int selectedMonth = Convert.ToInt32(drpMes.SelectedValue);
            mes.Attributes["class"] = " ";
            mes.Attributes.Add("class", " input-group-text text-dark");
            drpMes.CssClass = "form-control";
            if (selectedMonth < actualMonth)
            {
                //Display error message
                mes.Attributes.Add("class", "input-group-text text-danger border border-danger");
                drpMes.CssClass += " border border-danger";
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void dangerBorder()
        {
            num.Attributes.Add("class", "input-group-text text-danger border border-danger");
            txtTarjeta.CssClass = "form-control border border-danger";
        }

        protected void successBorder()
        {
            num.Attributes.Add("class", "input-group-text text-success border border-success");
            txtTarjeta.CssClass = "form-control border border-success";
        }
    }
}