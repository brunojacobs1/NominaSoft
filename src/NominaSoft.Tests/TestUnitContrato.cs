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
            contrato.FechaInicio= Convert.ToDateTime("02/01/2019");
            contrato.FechaFin = Convert.ToDateTime("02/11/2019");

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarFechaFin();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaFin2()
        {
            Contrato contrato = new Contrato();
            contrato.FechaInicio = Convert.ToDateTime("02/06/2019");
            contrato.FechaFin = Convert.ToDateTime("02/07/2019");

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarFechaFin();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaFin3()
        {
            Contrato contrato = new Contrato();
            contrato.FechaInicio = Convert.ToDateTime("02/01/2019");
            contrato.FechaFin = Convert.ToDateTime("02/07/2020");

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarFechaFin();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaInicio1()
        {
            Contrato contratoAnterior = new Contrato();
            contratoAnterior.FechaFin = Convert.ToDateTime("02/07/2019");

            Contrato contratoNuevo = new Contrato();
            contratoNuevo.FechaInicio = Convert.ToDateTime("02/08/2019");


            Boolean valorEsperado = true;
            Boolean valorObtenido = contratoNuevo.VerificarFechaInicio(contratoAnterior);
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaInicio2()
        {
            Contrato contratoAnterior = new Contrato();
            contratoAnterior.FechaFin = Convert.ToDateTime("14/08/2019");

            Contrato contratoNuevo = new Contrato();
            contratoNuevo.FechaInicio = Convert.ToDateTime("23/06/2019");


            Boolean valorEsperado = false;
            Boolean valorObtenido = contratoNuevo.VerificarFechaInicio(contratoAnterior);
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarFechaInicio3()
        {
            Contrato contratoAnterior = new Contrato();
            contratoAnterior.FechaFin = Convert.ToDateTime("23/06/2019");

            Contrato contratoNuevo = new Contrato();
            contratoNuevo.FechaInicio = Convert.ToDateTime("23/06/2019");


            Boolean valorEsperado = false;
            Boolean valorObtenido = contratoNuevo.VerificarFechaInicio(contratoAnterior);
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarTotalHorasSemanales1()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 10;

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarTotalHorasSemanales();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarTotalHorasSemanales2()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 4;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarTotalHorasSemanales();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarTotalHorasSemanales3()
        {
            Contrato contrato = new Contrato();
            contrato.TotalHorasSemanales = 50;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarTotalHorasSemanales();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarVigencia1()
        {
            Contrato contrato = new Contrato();
            contrato.FechaFin = Convert.ToDateTime("02/12/2019");
            contrato.EsAnulado = false;

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarVigencia();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarVigencia2()
        {
            Contrato contrato = new Contrato();
            contrato.FechaFin = Convert.ToDateTime("02/10/2019");
            contrato.EsAnulado = true;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarVigencia();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarVigencia3()
        {
            Contrato contrato = new Contrato();
            contrato.FechaFin = Convert.ToDateTime("20/09/2019");
            contrato.EsAnulado = false;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarVigencia();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarVigencia4()
        {
            Contrato contrato = new Contrato();
            contrato.FechaFin = Convert.ToDateTime("20/07/2019");
            contrato.EsAnulado = true;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarVigencia();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora1()
        {
            Empleado empleado = new Empleado();
            empleado.Grado = 0;
            Contrato contrato = new Contrato();
            contrato.Empleado = empleado;
            contrato.ValorHora = 6;

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora2()
        {
            Empleado empleado = new Empleado();
            empleado.Grado = 3;
            Contrato contrato = new Contrato();
            contrato.Empleado = empleado;
            contrato.ValorHora = 6;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora3()
        {
            Empleado empleado = new Empleado();
            empleado.Grado = 4;
            Contrato contrato = new Contrato();
            contrato.Empleado = empleado;
            contrato.ValorHora = 15;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora4()
        {
            Empleado empleado = new Empleado();
            empleado.Grado = 5;
            Contrato contrato = new Contrato();
            contrato.Empleado = empleado;
            contrato.ValorHora = 50;

            Boolean valorEsperado = true;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestVerificarValorHora5()
        {
            Empleado empleado = new Empleado();
            empleado.Grado = 1;
            Contrato contrato = new Contrato();
            contrato.Empleado = empleado;
            contrato.ValorHora = 28;

            Boolean valorEsperado = false;
            Boolean valorObtenido = contrato.VerificarValorHora();
            Assert.Equal<Boolean>(valorEsperado, valorObtenido);
        }
    }
}


