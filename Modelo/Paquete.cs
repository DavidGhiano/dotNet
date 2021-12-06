﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    abstract class Paquete
    {
        private int cantidadDia;
        private bool estado;
        private DateTime fechaViaje;
        private int idPaquete;
        private string nombre;
        private float precio;
        private int cantidadCuota;
        private float importeTotal;
        private List<Lugar> lugares;

        protected Paquete(
            int cantidadDia,
            bool estado, 
            DateTime fechaViaje,
            int idPaquete, 
            string nombre,
            float precio, 
            int cantidadCuota, 
            float importeTotal, 
            List<Lugar> lugares)
        {
            this.cantidadDia = cantidadDia;
            this.estado = estado;
            this.fechaViaje = fechaViaje;
            this.idPaquete = idPaquete;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidadCuota = cantidadCuota;
            this.importeTotal = importeTotal;
            this.lugares = lugares;
        }

        public int CantidadDia { get => cantidadDia; set => cantidadDia = value; }
        public bool Estado { get => estado; set => estado = value; }
        public DateTime FechaViaje { get => fechaViaje; set => fechaViaje = value; }
        public int IdPaquete { get => idPaquete; set => idPaquete = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public int CantidadCuota { get => cantidadCuota; set => cantidadCuota = value; }
        public float ImporteTotal { get => importeTotal; set => importeTotal = value; }
        public List<Lugar> Lugares { get => lugares; set => lugares = value; }

        public abstract float CalcularImporte();
        
    }
}
