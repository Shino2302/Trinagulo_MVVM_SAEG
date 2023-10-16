using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Trinagulo_MVVM_SAEG.Views;

namespace Trinagulo_MVVM_SAEG.ViewModel
{
    public class VMTipoTriangulo : BaseViewModel
    {
        #region VARIABLES
        double _Area;
        double _Perimetro;
        double _Base;
        double _Lado1;
        double _Lado2;
        string _TipoTriangulo;
        bool _Imagen1;
        bool _Imagen2;
        bool _Imagen3;
        #endregion
        #region CONSTRUCTOR
        public VMTipoTriangulo(INavigation navigation) 
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public double Area
        {
            get { return _Area; } 
            set { SetValue(ref _Area, value); }
        }
        public double Perimetro
        {
            get { return _Perimetro; }
            set { SetValue(ref _Perimetro, value); }
        }
        public double Base 
        {
            get { return _Base; }
            set { SetValue(ref _Base, value);}
        }
        public double Lado1
        {
            get { return _Lado1; }
            set { SetValue(ref _Lado1, value); }
        }
        public double Lado2
        {
            get { return _Lado2; }
            set { SetValue(ref _Lado2, value); }
        }
        public string TipoTriangulo
        {
            get { return _TipoTriangulo; }
            set { SetValue(ref _TipoTriangulo, value); }
        }
        public bool Imagen1
        {
            get { return _Imagen1; }
            set { SetValue(ref _Imagen1, value); }
        }
        public bool Imagen2
        {
            get { return _Imagen2; }
            set { SetValue(ref _Imagen2, value); }
        }
        public bool Imagen3
        {
            get { return _Imagen3; }
            set { SetValue(ref _Imagen3, value); }
        }
        #endregion
        #region PROCESOS
        public string Tipo(double Base, double Lado1, double Lado2)
        {
            if(Base > 0 && Lado1 > 0 && Lado2 > 0)
            {
                if (Base == Lado1 && Lado2 == Lado1)
                {
                    return "Equilatero";
                }
                if (Base != Lado1 && Base != Lado2 && Lado1 == Lado2)
                {
                    return "Isóceles";
                }
                else if (Base != Lado1 && Base != Lado2 && Lado1 != Lado2)
                {
                    return "Escaleno";
                }
                else
                {
                    return "No es un triangulo";
                }
            }
            else
            {
                return "No puede ser un triangulo";
            }
        }
        public double AreaEquilatero(double baseTriangulo)
        {
            return (Math.Pow(baseTriangulo, 2) * Math.Sqrt(3) / 4);
        }
        public double AreaIsoceles(double baseTriangulo, double lado1)
        {
            return (baseTriangulo / 4) * Math.Sqrt((4 * Math.Pow(lado1, 2)) - Math.Pow(baseTriangulo, 2));
        }
        public double AreaEscaleno(double baseTraingulo, double lado1, double lado2)
        {
            double semiPerimetro = (baseTraingulo + lado1 + lado2) / 2;
            return Math.Sqrt(semiPerimetro *
                (semiPerimetro - baseTraingulo) *
                (semiPerimetro - lado1) *
                (semiPerimetro - lado2));
        }
        public void Evento()
        {
            TipoTriangulo = Tipo(Base, Lado1, Lado2);
            switch (TipoTriangulo)
            {
                case "Equilatero":
                    Area = AreaEquilatero(Base);
                    Perimetro = Base * 3;
                    Imagen1 = true;
                    Imagen2 = false;
                    Imagen3 = false;
                    DisplayAlert($"Triandulo {TipoTriangulo}", $"con {Area} de área y {Perimetro} de perimetro", "Continuar");
                    break;
                case "Escaleno":
                    Area = AreaEscaleno(Base,Lado1,Lado2);
                    Perimetro = Base + Lado1 + Lado2;
                    Imagen1 = false;
                    Imagen2 = true;
                    Imagen3 = false;
                    DisplayAlert($"Triandulo {TipoTriangulo}", $"con {Area} de área y {Perimetro} de perimetro", "Continuar");
                    break;
                case "Isósceles":
                    Area = AreaIsoceles(Base, Lado1);
                    Perimetro = (Base + (Lado1 * 2));
                    Imagen1 = false;
                    Imagen2 = false;
                    Imagen3 = true;
                    DisplayAlert($"Triandulo {TipoTriangulo}", $"con {Area} de área y {Perimetro} de perimetro", "Continuar");
                    break;
                default:
                    DisplayAlert("Error", "No tienes un triangulo", "Cointinuar");
                    Imagen1 = false;
                    Imagen2 = false;
                    Imagen3 = false;
                    break;
            }
        }
        #endregion
        #region COMANDOS
        public ICommand EventoButton => new Command(Evento);
        #endregion
    }
}
