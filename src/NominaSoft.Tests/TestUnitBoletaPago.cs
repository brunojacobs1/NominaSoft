using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NominaSoft.Core.Entities;

namespace NominaSoft.Tests
{
    public class TestUnitBoletaPago
    {
        [Fact]
        public void TestCalcularTotalHorasBoleta1()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 10
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/03/2019"),
                FechaFin = Convert.ToDateTime("28/06/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            int valorEsperado = 170;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularTotalHorasBoleta2()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 25
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/01/2019"),
                FechaFin = Convert.ToDateTime("30/07/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            int valorEsperado = 750;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularTotalHorasBoleta3()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 15
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("11/03/2019"),
                FechaFin = Convert.ToDateTime("20/12/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            int valorEsperado = 600;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularTotalHorasBoleta4()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 8
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("23/05/2019"),
                FechaFin = Convert.ToDateTime("22/10/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            int valorEsperado = 168;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularTotalHorasBoleta5()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 19
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("10/07/2019"),
                FechaFin = Convert.ToDateTime("04/02/2020")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            int valorEsperado = 551;
            int valorObtenido = boleta.CalcularTotalHorasBoleta();
            Assert.Equal<int>(valorEsperado, valorObtenido);
        }

        [Fact]
        public void TestCalcularSueldoBasico1()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 19,
                ValorHora = 23
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("10/07/2019"),
                FechaFin = Convert.ToDateTime("04/02/2020")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            Double valorEsperado=12673;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularSueldoBasico2()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 15,
                ValorHora = 8
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("11/03/2019"),
                FechaFin = Convert.ToDateTime("20/12/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            Double valorEsperado = 4800;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularSueldoBasico3()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 10,
                ValorHora = 37
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/03/2019"),
                FechaFin = Convert.ToDateTime("28/06/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            Double valorEsperado = 6290;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularSueldoBasico4()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 8,
                ValorHora = 60
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("23/05/2019"),
                FechaFin = Convert.ToDateTime("22/10/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            Double valorEsperado = 10080;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularSueldoBasico5()
        {
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 25,
                ValorHora = 13
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/01/2019"),
                FechaFin = Convert.ToDateTime("30/07/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            Double valorEsperado = 9750;
            Double valorObtenido = boleta.CalcularSueldoBasico();
            Assert.Equal<Double>(valorEsperado, valorObtenido);

        }

        [Fact]
        public void TestCalcularDescuentoPorAfp1()
        {
            int decimales = 5;
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.1
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 19,
                ValorHora = 23,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("10/07/2019"),
                FechaFin = Convert.ToDateTime("04/02/2020")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            double valorEsperado = 1267.3;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularDescuentoPorAfp2()
        {
            int decimales = 5;
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.18
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 15,
                ValorHora = 8,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("11/03/2019"),
                FechaFin = Convert.ToDateTime("20/12/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            double valorEsperado = 864;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularDescuentoPorAfp3()
        {
            int decimales = 5;
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0135
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 8,
                ValorHora = 60,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("23/05/2019"),
                FechaFin = Convert.ToDateTime("22/10/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            double valorEsperado = 136.08;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularDescuentoPorAfp4()
        {
            int decimales = 5;
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0135
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 10,
                ValorHora = 37,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/03/2019"),
                FechaFin = Convert.ToDateTime("28/06/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            double valorEsperado = 84.915;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularDescuentoPorAfp5()
        {
            int decimales = 5;
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0125
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 25,
                ValorHora = 13,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/01/2019"),
                FechaFin = Convert.ToDateTime("30/07/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            double valorEsperado = 121.875;
            double valorObtenido = boleta.CalcularDescuentoPorAfp();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos1()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 200,
                MontoPorAdelantos = 50,
                MontoPorHorasAusentes = 35
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.1
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 19,
                ValorHora = 23,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("10/07/2019"),
                FechaFin = Convert.ToDateTime("04/02/2020")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = concepto
            };

            double valorEsperado =1552.3;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos2()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 37,
                MontoPorAdelantos = 400,
                MontoPorHorasAusentes = 0
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.18
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 15,
                ValorHora = 8,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("11/03/2019"),
                FechaFin = Convert.ToDateTime("20/12/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = concepto
            };

            double valorEsperado = 1301;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos3()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 379.56,
                MontoPorAdelantos = 528,
                MontoPorHorasAusentes = 25.34
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0135
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 8,
                ValorHora = 60,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("23/05/2019"),
                FechaFin = Convert.ToDateTime("22/10/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = concepto
            };

            double valorEsperado = 1068.98;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos4()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 3268.1,
                MontoPorAdelantos = 1405.45,
                MontoPorHorasAusentes = 53
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0135
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 10,
                ValorHora = 37,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/03/2019"),
                FechaFin = Convert.ToDateTime("28/06/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = concepto
            };

            double valorEsperado = 4811.465;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalDescuentos5()
        {
            int decimales = 5;
            ConceptosDePago concepto = new ConceptosDePago
            {
                MontoDeOtrosDescuentos = 207.6,
                MontoPorAdelantos = 0,
                MontoPorHorasAusentes = 0
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0125
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 25,
                ValorHora = 13,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/01/2019"),
                FechaFin = Convert.ToDateTime("30/07/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = concepto
            };

            double valorEsperado = 329.475;
            double valorObtenido = boleta.CalcularTotalDescuentos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalIngresos1()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 100.50,
                MontoPorReintegro = 30,
                MontoPorHorasExtra = 50.50
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 19,
                ValorHora = 23,
                EsAsignacionFamiliar = false
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("10/07/2019"),
                FechaFin = Convert.ToDateTime("04/02/2020")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 12854;
            double valorObtenido = boleta.CalcularTotalIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalIngresos2()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 400.23,
                MontoPorReintegro = 183.5,
                MontoPorHorasExtra = 90.42,
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 15,
                ValorHora = 8,
                EsAsignacionFamiliar = false
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("11/03/2019"),
                FechaFin = Convert.ToDateTime("20/12/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 5474.15;
            double valorObtenido = boleta.CalcularTotalIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalIngresos3()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 873.34,
                MontoPorReintegro = 64.2,
                MontoPorHorasExtra = 0
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 8,
                ValorHora = 60,
                EsAsignacionFamiliar = true
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("23/05/2019"),
                FechaFin = Convert.ToDateTime("22/10/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 11110.54;
            double valorObtenido = boleta.CalcularTotalIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularTotalIngresos4()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 475.34,
                MontoPorReintegro = 12.2,
                MontoPorHorasExtra = 34.43
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 10,
                ValorHora = 37,
                EsAsignacionFamiliar = true
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/03/2019"),
                FechaFin = Convert.ToDateTime("28/06/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 6904.97;
            double valorObtenido = boleta.CalcularTotalIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }


        [Fact]
        public void TestCalcularTotalIngresos5()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 0,
                MontoPorReintegro = 202.1,
                MontoPorHorasExtra = 540.23
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 25,
                ValorHora = 13,
                EsAsignacionFamiliar = false
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/01/2019"),
                FechaFin = Convert.ToDateTime("30/07/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 10492.33;
            double valorObtenido = boleta.CalcularTotalIngresos();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSueldoNeto1()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 100.50,
                MontoPorReintegro = 30,
                MontoPorHorasExtra = 50.50,
                MontoDeOtrosDescuentos = 200,
                MontoPorAdelantos = 50,
                MontoPorHorasAusentes = 35
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.1
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 19,
                ValorHora = 23,
                EsAsignacionFamiliar = false,
                AFP=afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("10/07/2019"),
                FechaFin = Convert.ToDateTime("04/02/2020")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 11301.7;
            double valorObtenido = boleta.CalcularSueldoNeto();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSueldoNeto2()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 400.23,
                MontoPorReintegro = 183.5,
                MontoPorHorasExtra = 90.42,
                MontoDeOtrosDescuentos = 37,
                MontoPorAdelantos = 400,
                MontoPorHorasAusentes = 0
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.18
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 15,
                ValorHora = 8,
                EsAsignacionFamiliar = false,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("11/03/2019"),
                FechaFin = Convert.ToDateTime("20/12/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 4173.15;
            double valorObtenido = boleta.CalcularSueldoNeto();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSueldoNeto3()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 873.34,
                MontoPorReintegro = 64.2,
                MontoPorHorasExtra = 0,
                MontoDeOtrosDescuentos = 379.56,
                MontoPorAdelantos = 528,
                MontoPorHorasAusentes = 25.34
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0135
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 8,
                ValorHora = 60,
                EsAsignacionFamiliar = true,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("23/05/2019"),
                FechaFin = Convert.ToDateTime("22/10/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 10041.56;
            double valorObtenido = boleta.CalcularSueldoNeto();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSueldoNeto4()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 475.34,
                MontoPorReintegro = 12.2,
                MontoPorHorasExtra = 34.43,
                MontoDeOtrosDescuentos = 3268.1,
                MontoPorAdelantos = 1405.45,
                MontoPorHorasAusentes = 53
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0135
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 10,
                ValorHora = 37,
                EsAsignacionFamiliar = true,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/03/2019"),
                FechaFin = Convert.ToDateTime("28/06/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 2093.505;
            double valorObtenido = boleta.CalcularSueldoNeto();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }

        [Fact]
        public void TestCalcularSueldoNeto5()
        {
            int decimales = 5;
            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoDeOtrosIngresos = 0,
                MontoPorReintegro = 202.1,
                MontoPorHorasExtra = 540.23,
                MontoDeOtrosDescuentos = 207.6,
                MontoPorAdelantos = 0,
                MontoPorHorasAusentes = 0
            };
            AFP afp = new AFP
            {
                PorcentajeDescuento = 0.0125
            };
            Contrato contrato = new Contrato
            {
                TotalHorasSemanales = 25,
                ValorHora = 13,
                EsAsignacionFamiliar = false,
                AFP = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01/01/2019"),
                FechaFin = Convert.ToDateTime("30/07/2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptosDePago
            };

            double valorEsperado = 10162.855;
            double valorObtenido = boleta.CalcularSueldoNeto();
            Assert.Equal<double>(Math.Round(valorEsperado, decimales), Math.Round(valorObtenido, decimales));
        }
    }
}
