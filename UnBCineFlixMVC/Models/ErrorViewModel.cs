using System;

namespace UnBCineFlixMVC.Models
{
    /// <summary>
    /// Classe Erro na visualizacao do Modelo
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Funcao Requisicao de Identidade
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Funcao Mostrar Requisicao de Identificacao
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}