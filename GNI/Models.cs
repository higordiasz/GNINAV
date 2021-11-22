using GNINAV.Models.Instagrams;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNINAV.GNI.Models
{
    //Retornos

    class InstaGNI
    {
        public Instagram Insta { get; set; }
        public string ContaID { get; set; }
        public string PictureURL { get; set; }
        public bool isLogged { get; set; }
        public int Seguir { get; set; }
        public int Curtir { get; set; }
        public int Total { get; set; }
    }

    class SenderLoginGNI
    {
        private string sha1 = "736e0a9928fc3407bf55c67ef77afcbe15303258";
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("sha1")]
        public string Sha1 { get { return sha1; }  }
    }

    class SenderUsernameInsta
    {
        private string sha1 = "736e0a9928fc3407bf55c67ef77afcbe15303258";
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("sha1")]
        public string Sha1 { get { return sha1; } }
        [JsonProperty("SESSIONID")]
        public string SESSIONID { get; set; }
        [JsonProperty("nome_usuario")]
        public string Username { get; set; }
    }

    class SenderActionRequest
    {
        private string sha1 = "736e0a9928fc3407bf55c67ef77afcbe15303258";
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("sha1")]
        public string Sha1 { get { return sha1; } }
        [JsonProperty("SESSIONID")]
        public string SESSIONID { get; set; }
        [JsonProperty("id_conta")]
        public string ContaID { get; set; }
    }

    class SenderConfirmarTask
    {
        private string sha1 = "736e0a9928fc3407bf55c67ef77afcbe15303258";
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("sha1")]
        public string Sha1 { get { return sha1; } }
        [JsonProperty("SESSIONID")]
        public string SESSIONID { get; set; }
        [JsonProperty("id_conta")]
        public string ContaID { get; set; }
        [JsonProperty("id_pedido")]
        public string TaskID { get; set; }
        [JsonProperty("tipo")]
        public int Tipo { get; set; }
    }

    //Requisições

    //{"status":"success","id_conta":"XXXXXXXXXXXXXXX"}

    class ReturnID
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("id_conta")]
        public string ContaID { get; set; }
    }

    //{"status":"fail","message":"EMPTY"}

    class ReturnStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    //{"status":"success","id_usuario":"XXXXXXXXXXXXXXX","email_usuario":"XXXXXXXXXXXXXXX","message":"SUCESSO_LOGIN","SESSIONID":"XXXXXXXXXXXXXXX"}

    class ReturnLogin
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("id_usuario")]
        public string UserID { get; set; }
        [JsonProperty("email_usuario")]
        public string EmailGNI { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("SESSIONID")]
        public string SESSIONID { get; set; }
    }

    class Retorno
    {
        public int Status { get; set; }
        public string Response { get; set; }
    }

    //{"status":"ENCONTRADA","id_pedido":XXXXXXXXXXXXXXX,"url":"XXXXXXXXXXXXXXX","id_alvo":"XXXXXXXXXXXXXXX","tipo_acao":"TIPO_ACAO"}

    class ReturnTask
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("id_pedido")]
        public string PedidoID { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("id_alvo")]
        public string AlvoID { get; set; }
        [JsonProperty("tipo_acao")]
        public string Tipo { get; set; }
    }
}
