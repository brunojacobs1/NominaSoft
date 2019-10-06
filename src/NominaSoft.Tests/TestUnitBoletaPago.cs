using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NominaSoft.Core;
using NominaSoft.Core.Entities;
using Core.Entities;

namespace NominaSoft.Tests
{
    public class TestUnitBoletaPago
    {
        [Fact]
        public void TestCalcularTotalHorasBoleta1()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 10;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("01/03/2019");
            periodo.FechaFin = Convert.ToDateTime("28/06/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            int valorEsperado = 170;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularTotalHorasBoleta2()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 25;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("01/01/2019");
            periodo.FechaFin = Convert.ToDateTime("30/07/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            int valorEsperado = 750;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularTotalHorasBoleta3()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 15;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("11/03/2019");
            periodo.FechaFin = Convert.ToDateTime("20/12/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            int valorEsperado = 600;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularTotalHorasBoleta4()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 8;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("23/05/2019");
            periodo.FechaFin = Convert.ToDateTime("22/10/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            int valorEsperado = 168;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularTotalHorasBoleta5()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 19;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("10/07/2019");
            periodo.FechaFin = Convert.ToDateTime("04/02/2020");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            int valorEsperado = 551;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularSueldoBasico1()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 19;
            contrato.ValorHora = 23;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("10/07/2019");
            periodo.FechaFin = Convert.ToDateTime("04/02/2020");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            Double valorEsperado=12673;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularSueldoBasico2()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 15;
            contrato.ValorHora = 8;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("11/03/2019");
            periodo.FechaFin = Convert.ToDateTime("20/12/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            Double valorEsperado = 4800;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularSueldoBasico3()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 10;
            contrato.ValorHora = 37;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("01/03/2019");
            periodo.FechaFin = Convert.ToDateTime("28/06/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo; 

            Double valorEsperado = 6290;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularSueldoBasico4()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 8;
            contrato.ValorHora = 60;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("23/05/2019");
            periodo.FechaFin = Convert.ToDateTime("22/10/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            Double valorEsperado = 10080;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularSueldoBasico5()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 25;
            contrato.ValorHora = 13;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("01/01/2019");
            periodo.FechaFin = Convert.ToDateTime("30/07/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            Double valorEsperado = 9750;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularDescuentoPorAfp1()
        {
            int decimales = 5;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.1;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 19;
            contrato.ValorHora = 23;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("10/07/2019");
            periodo.FechaFin = Convert.ToDateTime("04/02/2020");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            double valorEsperado = 1267.3;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularDescuentoPorAfp2()
        {
            int decimales = 5;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.18;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 15;
            contrato.ValorHora = 8;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("11/03/2019");
            periodo.FechaFin = Convert.ToDateTime("20/12/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            double valorEsperado = 864;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularDescuentoPorAfp3()
        {
            int decimales = 5;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.0135;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 8;
            contrato.ValorHora = 60;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("23/05/2019");
            periodo.FechaFin = Convert.ToDateTime("22/10/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            double valorEsperado = 136.08;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularDescuentoPorAfp4()
        {
            int decimales = 5;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.0135;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 10;
            contrato.ValorHora = 37;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("01/03/2019");
            periodo.FechaFin = Convert.ToDateTime("28/06/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            double valorEsperado = 84.915;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularDescuentoPorAfp5()
        {
            int decimales = 5;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.0125;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 25;
            contrato.ValorHora = 13;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("01/01/2019");
            periodo.FechaFin = Convert.ToDateTime("30/07/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;

            double valorEsperado = 121.875;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos1()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago();
            concepto.MontoDeOtrosDescuentos = 200;
            concepto.MontoPorAdelantos = 50;
            concepto.MontoPorHorasAusentes = 35;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.1;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 19;
            contrato.ValorHora = 23;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("10/07/2019");
            periodo.FechaFin = Convert.ToDateTime("04/02/2020");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;
            boleta.ConceptosDePago = concepto;

            double valorEsperado =1552.3;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos2()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago();
            concepto.MontoDeOtrosDescuentos = 37;
            concepto.MontoPorAdelantos = 400;
            concepto.MontoPorHorasAusentes = 0;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.18;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 15;
            contrato.ValorHora = 8;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("11/03/2019");
            periodo.FechaFin = Convert.ToDateTime("20/12/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;
            boleta.ConceptosDePago = concepto;

            double valorEsperado = 1301;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos3()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago();
            concepto.MontoDeOtrosDescuentos = 379.56;
            concepto.MontoPorAdelantos = 528;
            concepto.MontoPorHorasAusentes = 25.34;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.0135;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 8;
            contrato.ValorHora = 60;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("23/05/2019");
            periodo.FechaFin = Convert.ToDateTime("22/10/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;
            boleta.ConceptosDePago = concepto;

            double valorEsperado = 1068.98;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos4()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago();
            concepto.MontoDeOtrosDescuentos = 3268.1;
            concepto.MontoPorAdelantos = 1405.45;
            concepto.MontoPorHorasAusentes = 53;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.0135;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 10;
            contrato.ValorHora = 37;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("01/03/2019");
            periodo.FechaFin = Convert.ToDateTime("28/06/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;
            boleta.ConceptosDePago = concepto;

            double valorEsperado = 4811.465;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos5()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago();
            concepto.MontoDeOtrosDescuentos = 207.6;
            concepto.MontoPorAdelantos = 0;
            concepto.MontoPorHorasAusentes = 0;
            AFP afp = new AFP();
            afp.PorcentajeDescuento = 0.0125;
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 25;
            contrato.ValorHora = 13;
            contrato.AFP = afp;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("01/01/2019");
            periodo.FechaFin = Convert.ToDateTime("30/07/2019");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;
            boleta.ConceptosDePago = concepto;

            double valorEsperado = 329.475;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalIngresos1()
        {
            ConceptosDePago concepto = new ConceptosDePago();
            
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 19;
            contrato.ValorHora = 23;
            PeriodoPago periodo = new PeriodoPago();
            periodo.FechaInicio = Convert.ToDateTime("10/07/2019");
            periodo.FechaFin = Convert.ToDateTime("04/02/2020");
            BoletaPago boleta = new BoletaPago();
            boleta.Contrato = contrato;
            boleta.PeriodoPago = periodo;
        }
        //MontoPorHorasAusentes +
        //MontoDeOtrosIngresos +
        //MontoPorHorasExtra;
        //public double CalcularTotalIngresos() => CalcularSueldoBasico() + Contrato.CalcularAsignacionFamiliar() + ConceptosDePago.CalcularSumatoriaIngresos();

        //public double CalcularSueldoNeto() => CalcularTotalIngresos() + CalcularTotalDescuentos();
    }
}
