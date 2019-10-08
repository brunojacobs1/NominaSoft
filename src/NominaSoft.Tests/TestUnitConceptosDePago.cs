using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NominaSoft.Core.Entities;

namespace NominaSoft.Tests
{
    public class TestUnitConceptosDePago
    {
        [Fact]
        public void TestCalcularSumatoriaDescuentos1()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 200,
                MontoPorAdelantos = 100,
                MontoPorHorasAusentes = 0
            };

            double valorEsperado = 300;
            double valorObtenido = conceptosDePago.CalcularSumatoriaDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaDescuentos2()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 150.33,
                MontoPorAdelantos = 322.22,
                MontoPorHorasAusentes = 50.64
            };

            double valorEsperado = 523.19;
            double valorObtenido = conceptosDePago.CalcularSumatoriaDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaDescuentos3()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 342.29,
                MontoPorAdelantos = 50.38,
                MontoPorHorasAusentes = 63.01
            };

            double valorEsperado = 455.68;
            double valorObtenido = conceptosDePago.CalcularSumatoriaDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaDescuentos4()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 123.52,
                MontoPorAdelantos = 630,
                MontoPorHorasAusentes = 0
            };

            double valorEsperado = 753.52;
            double valorObtenido = conceptosDePago.CalcularSumatoriaDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaDescuentos5()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 0,
                MontoPorAdelantos = 93,
                MontoPorHorasAusentes = 0
            };

            double valorEsperado = 93;
            double valorObtenido = conceptosDePago.CalcularSumatoriaDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaIngresos1()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoPorReintegro = 50,
                MontoDeOtrosIngresos = 100,
                MontoPorHorasExtra = 30
            };

            double valorEsperado = 180;
            double valorObtenido = conceptosDePago.CalcularSumatoriaIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaIngresos2()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoPorReintegro = 300.53,
                MontoDeOtrosIngresos = 150.35,
                MontoPorHorasExtra = 15.55
            };

            double valorEsperado = 466.43;
            double valorObtenido = conceptosDePago.CalcularSumatoriaIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaIngresos3()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoPorReintegro = 392.24,
                MontoDeOtrosIngresos = 72.04,
                MontoPorHorasExtra = 97.50
            };

            double valorEsperado = 561.78;
            double valorObtenido = conceptosDePago.CalcularSumatoriaIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaIngresos4()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoPorReintegro = 525.25,
                MontoDeOtrosIngresos = 0,
                MontoPorHorasExtra = 30.50
            };

            double valorEsperado = 555.75;
            double valorObtenido = conceptosDePago.CalcularSumatoriaIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSumatoriaIngresos5()
        {
            int decimales = 5;

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoPorReintegro = 0,
                MontoDeOtrosIngresos = 0,
                MontoPorHorasExtra = 0
            };



            double valorEsperado = 0;
            double valorObtenido = conceptosDePago.CalcularSumatoriaIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }
    }
}
