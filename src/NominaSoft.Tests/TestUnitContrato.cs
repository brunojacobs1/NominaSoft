using System;
using Xunit;
using Core.Entities;

namespace NominaSoft.Test
{
    public class TestUnitContrato
    {
        [Fact]
        public void TestCalcularAsignacionFamiliar1()
        {
            Contrato contrato = new Contrato();
            contrato.EsAsignacionFamiliar = true;

            Double valorEsperado = 93.00;
            Double valorObtenido = contrato.CalcularAsignacionFamiliar();

            Assert.Equal<Double>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularAsignacionFamiliar2()
        {
            Contrato contrato = new Contrato();
            contrato.EsAsignacionFamiliar = false;

            Double valorEsperado = 0;
            Double valorObtenido = contrato.CalcularAsignacionFamiliar();

            Assert.Equal<Double>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaFin1()
        {
            Contrato contrato = new Contrato();
            contrato.FechaInicio= Convert.ToDateTime("01/02/2019");
            contrato.FechaFin = Convert.ToDateTime("11/02/2019");

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarFechaFin();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaFin2()
        {
            Contrato contrato = new Contrato();
            contrato.FechaInicio = Convert.ToDateTime("06/02/2019");
            contrato.FechaFin = Convert.ToDateTime("07/02/2019");

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarFechaFin();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaFin3()
        {
            Contrato contrato = new Contrato();
            contrato.FechaInicio = Convert.ToDateTime("01/02/2019");
            contrato.FechaFin = Convert.ToDateTime("07/02/2020");

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarFechaFin();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaInicio1()
        {
            Contrato contratoAnterior = new Contrato();
            contratoAnterior.FechaFin = Convert.ToDateTime("07/02/2019");

            Contrato contratoNuevo = new Contrato();
            contratoNuevo.FechaInicio = Convert.ToDateTime("08/02/2019");


            Boolean valorEsperado = true;
            Boolean valorObtenido = contratoNuevo.VerificarFechaInicio(contratoAnterior);
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaInicio2()
        {
            Contrato contratoAnterior = new Contrato();
            contratoAnterior.FechaFin = Convert.ToDateTime("08/14/2019");

            Contrato contratoNuevo = new Contrato();
            contratoNuevo.FechaInicio = Convert.ToDateTime("06/23/2019");


            Boolean valorEsperado = false;
            Boolean valorObtenido = contratoNuevo.VerificarFechaInicio(contratoAnterior);
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaInicio3()
        {
            Contrato contratoAnterior = new Contrato();
            contratoAnterior.FechaFin = Convert.ToDateTime("06/23/2019");

            Contrato contratoNuevo = new Contrato();
            contratoNuevo.FechaInicio = Convert.ToDateTime("06/23/2019");


            Boolean valorEsperado = false;
            Boolean valorObtenido = contratoNuevo.VerificarFechaInicio(contratoAnterior);
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarTotalHora1()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 10;

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarTotalHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarTotalHora2()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 4;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarTotalHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarTotalHora3()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 50;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarTotalHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarVigencia1()
        {
            Contrato contrato = new Contrato();
            contrato.FechaFin = Convert.ToDateTime("12/02/2019");
            contrato.EsAnulado = false;

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarVigencia();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarVigencia2()
        {
            Contrato contrato = new Contrato();
            contrato.FechaFin = Convert.ToDateTime("10/02/2019");
            contrato.EsAnulado = true;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarVigencia();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarVigencia3()
        {
            Contrato contrato = new Contrato();
            contrato.FechaFin = Convert.ToDateTime("09/20/2019");
            contrato.EsAnulado = false;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarVigencia();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarVigencia4()
        {
            Contrato contrato = new Contrato();
            contrato.FechaFin = Convert.ToDateTime("07/20/2019");
            contrato.EsAnulado = true;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarVigencia();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora1()
        {
            Contrato contrato = new Contrato();
            contrato.Empleado.Grado = 0;
            contrato.ValorHora = 6;

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora2()
        {
            Contrato contrato = new Contrato();
            contrato.Empleado.Grado = 3;
            contrato.ValorHora = 6;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora3()
        {
            Contrato contrato = new Contrato();
            contrato.Empleado.Grado = 4;
            contrato.ValorHora = 15;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora4()
        {
            Contrato contrato = new Contrato();
            contrato.Empleado.Grado = 5;
            contrato.ValorHora = 50;

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora5()
        {
            Contrato contrato = new Contrato();
            contrato.Empleado.Grado = 1;
            contrato.ValorHora = 28;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }
    }
}


