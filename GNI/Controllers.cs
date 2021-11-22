using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using GNINAV.GNI.Models;

namespace GNINAV.GNI.Controllers
{
    class GniController
    {
        //Login - https://www.ganharnoinsta.com/api/login.php

        public static ReturnLogin LoginGNI(string Token)
        {
            var Receiver = new ReturnLogin
            {
                Status = "fail",
                Message = $"Não foi possivel conectar com a API.",
                EmailGNI = "",
                SESSIONID = "",
                UserID = ""
            };
            try
            {
                if (String.IsNullOrEmpty(Token))
                {
                    return Receiver;
                }
                SenderLoginGNI Sender = new SenderLoginGNI
                {
                    Token = Token
                };
                using (var cliente = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    cliente.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
                    string adress = "https://www.ganharnoinsta.com/api/login.php";
                    var serializedSender = JsonConvert.SerializeObject(Sender);
                    var content = new StringContent(serializedSender, Encoding.UTF8, "application/json");
                    var request = cliente.PostAsync(adress, content).Result;
                    if (request.IsSuccessStatusCode)
                    {
                        var aux = request.Content.ReadAsStringAsync().Result;
                        if (aux.IndexOf("success") > -1)
                        {
                            Receiver = JsonConvert.DeserializeObject<ReturnLogin>(aux);
                            return Receiver;
                        } else
                        {
                            var Retorno = JsonConvert.DeserializeObject<ReturnStatus>(aux);
                            Receiver.Message = Retorno.Message;
                            Receiver.Status = Retorno.Status;
                            return Receiver;
                        }
                    }
                    return Receiver;
                }
            }
            catch (Exception err)
            {
                Receiver.Status = "fail";
                Receiver.Message = $"Erro ao realizar a requisição: '{err.Message}'.";
                return null;
            }
        }

        //CheckAccount - https://www.ganharnoinsta.com/api/check_account.php

        public static ReturnID CheckAccount(string Token, string Username, string SESSIONID)
        {
            var Receiver = new ReturnID
            {
                Status = "fail",
                ContaID = "Não foi possivel conectar coma API."
            };
            try
            {
                if (String.IsNullOrEmpty(Username))
                {
                    return Receiver;
                }
                if (String.IsNullOrEmpty(SESSIONID))
                {
                    return Receiver;
                }
                if (String.IsNullOrEmpty(Token))
                {
                    return Receiver;
                }
                SenderUsernameInsta Sender = new SenderUsernameInsta
                {
                    Token = Token,
                    SESSIONID = SESSIONID,
                    Username = Username
                };
                using (var cliente = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    cliente.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
                    string adress = "https://www.ganharnoinsta.com/api/check_account.php";
                    var serializedSender = JsonConvert.SerializeObject(Sender);
                    var content = new StringContent(serializedSender, Encoding.UTF8, "application/json");
                    var request = cliente.PostAsync(adress, content).Result;
                    if (request.IsSuccessStatusCode)
                    {
                        var aux = request.Content.ReadAsStringAsync().Result;
                        if (aux.IndexOf("success") > -1)
                        {
                            Receiver = JsonConvert.DeserializeObject<ReturnID>(aux);
                            return Receiver;
                        }
                        else
                        {
                            var Retorno = JsonConvert.DeserializeObject<ReturnStatus>(aux);
                            Receiver.ContaID = Retorno.Message;
                            Receiver.Status = Retorno.Status;
                            return Receiver;
                        }
                    }
                    return Receiver;
                }
            }
            catch (Exception err)
            {
                Receiver.Status = "fail";
                Receiver.ContaID = $"Erro ao realizar a requisição: '{err.Message}'.";
                return null;
            }
        }

        //Get Action - https://www.ganharnoinsta.com/api/get_action.php

        public static ReturnTask GetTask(string Token, string ContaID, string SESSIONID)
        {
            var Receiver = new ReturnTask
            {
                Status = "fail",
                Tipo = "Não foi possivel conectar coma API.",
                AlvoID = "",
                PedidoID = "",
                URL = ""
            };
            try
            {
                if (String.IsNullOrEmpty(ContaID))
                {
                    return Receiver;
                }
                if (String.IsNullOrEmpty(SESSIONID))
                {
                    return Receiver;
                }
                if (String.IsNullOrEmpty(Token))
                {
                    return Receiver;
                }
                SenderActionRequest Sender = new SenderActionRequest
                {
                    Token = Token,
                    SESSIONID = SESSIONID,
                    ContaID = ContaID
                };
                using (var cliente = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    cliente.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
                    string adress = "https://www.ganharnoinsta.com/api/get_action.php";
                    var serializedSender = JsonConvert.SerializeObject(Sender);
                    var content = new StringContent(serializedSender, Encoding.UTF8, "application/json");
                    var request = cliente.PostAsync(adress, content).Result;
                    if (request.IsSuccessStatusCode)
                    {
                        var aux = request.Content.ReadAsStringAsync().Result;
                        if (aux.IndexOf("ENCONTRADA") > -1)
                        {
                            Receiver = JsonConvert.DeserializeObject<ReturnTask>(aux);
                            return Receiver;
                        }
                        else
                        {
                            if (aux.IndexOf("NAO_ENCONTRADA") > -1)
                            {
                                Receiver.Tipo = "Não foi encontrada tarefa para a conta atual";
                                Receiver.Status = "NAO_ENCONTRADA";
                                return Receiver;
                            }
                            else
                            {
                                var Retorno = JsonConvert.DeserializeObject<ReturnStatus>(aux);
                                Receiver.Tipo = Retorno.Message;
                                Receiver.Status = Retorno.Status;
                                return Receiver;
                            }
                        }
                    }
                    return Receiver;
                }
            }
            catch (Exception err)
            {
                Receiver.Status = "fail";
                Receiver.Tipo = $"Erro ao realizar a requisição: '{err.Message}'.";
                return null;
            }
        }

        //Confirm Action - https://www.ganharnoinsta.com/api/confirm_action.php

        public static ReturnStatus ConfirmTask(string Token, string ContaID, string SESSIONID, string TaskID, int Tipo)
        {
            var Receiver = new ReturnStatus
            {
                Status = "interno",
                Message = "Não foi possivel conectar coma API."
            };
            try
            {
                if (String.IsNullOrEmpty(ContaID))
                {
                    return Receiver;
                }
                if (String.IsNullOrEmpty(SESSIONID))
                {
                    return Receiver;
                }
                if (String.IsNullOrEmpty(Token))
                {
                    return Receiver;
                }
                SenderConfirmarTask Sender = new SenderConfirmarTask
                {
                    Token = Token,
                    SESSIONID = SESSIONID,
                    ContaID = ContaID,
                    TaskID = TaskID,
                    Tipo = Tipo
                };
                using (var cliente = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    cliente.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
                    string adress = "https://www.ganharnoinsta.com/api/confirm_action.php";
                    var serializedSender = JsonConvert.SerializeObject(Sender);
                    var content = new StringContent(serializedSender, Encoding.UTF8, "application/json");
                    var request = cliente.PostAsync(adress, content).Result;
                    if (request.IsSuccessStatusCode)
                    {
                        var aux = request.Content.ReadAsStringAsync().Result;
                        if (aux.IndexOf("success") > -1)
                        {
                            Receiver = JsonConvert.DeserializeObject<ReturnStatus>(aux);
                            return Receiver;
                        }
                        else
                        {
                            Receiver = JsonConvert.DeserializeObject<ReturnStatus>(aux);
                            return Receiver;
                        }
                    }
                    return Receiver;
                }
            }
            catch (Exception err)
            {
                Receiver.Status = "interno";
                Receiver.Message = $"Erro ao realizar a requisição: '{err.Message}'.";
                return null;
            }
        }

    }
}
