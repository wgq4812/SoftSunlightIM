using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SoftSunlight.Tool
{
    /// <summary>
    /// Http请求工具类
    /// </summary>
    public class WebUtils
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <returns></returns>
        public string DoGet(string requestUrl)
        {
            return DoGet(requestUrl, null, null);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="requestParam">请求参数</param>
        /// <returns></returns>
        public string DoGet(string requestUrl, Dictionary<string, string> requestParam)
        {
            return DoGet(requestUrl, requestParam, null);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="requestParam">请求参数</param>
        /// <param name="headerParam">请求头</param>
        /// <returns></returns>
        public string DoGet(string requestUrl, Dictionary<string, string> requestParam, Dictionary<string, string> headerParam)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            StreamReader sr = null;
            string responseText = string.Empty;
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(BuildRequestUrl(requestUrl, requestParam));
                httpWebRequest.Method = "GET";
                BuildRequestHeader(httpWebRequest, headerParam);
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                sr = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding(httpWebResponse.CharacterSet));
                responseText = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                //记录日志
                Log.Write(ex.Message, ex);
            }
            finally
            {
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                    httpWebRequest = null;
                }
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                    httpWebResponse.Dispose();
                    httpWebResponse = null;
                }
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
            return responseText;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <returns></returns>
        public string DoPost(string requestUrl)
        {
            return DoPost(requestUrl, null, null);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="requestParam">请求参数</param>
        /// <returns></returns>
        public string DoPost(string requestUrl, Dictionary<string, string> requestParam)
        {
            return DoPost(requestUrl, requestParam, null);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="requestParam">请求参数</param>
        /// <param name="headerParam">请求头</param>
        /// <returns></returns>
        public string DoPost(string requestUrl, Dictionary<string, string> requestParam, Dictionary<string, string> headerParam)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            StreamReader sr = null;
            string responseText = string.Empty;
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                httpWebRequest.Method = "POST";
                BuildRequestHeader(httpWebRequest, headerParam);
                string postDataString = BuildFormBody(requestParam);
                if (headerParam != null && headerParam.Count > 0)
                {
                    foreach (string key in headerParam.Keys)
                    {
                        if (key.Equals("content-type", StringComparison.CurrentCultureIgnoreCase) && headerParam[key].Contains("application/json"))
                        {
                            postDataString = JsonConvert.SerializeObject(requestParam);
                        }
                    }
                }
                Stream stream = httpWebRequest.GetRequestStream();
                byte[] postBytes = Encoding.UTF8.GetBytes(postDataString);
                stream.Write(postBytes, 0, postBytes.Length);
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                sr = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding(httpWebResponse.CharacterSet));
                responseText = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                //记录日志
                Log.Write(ex.Message, ex);
            }
            finally
            {
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                    httpWebRequest = null;
                }
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                    httpWebResponse.Dispose();
                    httpWebResponse = null;
                }
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
            return responseText;
        }

        /// <summary>
        /// 构造请求地址
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        private string BuildRequestUrl(string requestUrl, Dictionary<string, string> requestParam)
        {
            if (requestParam == null || requestParam.Count <= 0)
            {
                return requestUrl;
            }
            StringBuilder urlBuilder = new StringBuilder();
            foreach (string key in requestParam.Keys)
            {
                urlBuilder.Append(key).Append("=").Append(requestParam[key]).Append("&");
            }
            if (requestUrl.LastIndexOf("?") == requestUrl.Length - 1)
            {
                return requestUrl + urlBuilder.ToString();
            }
            else
            {
                return requestUrl + "?" + urlBuilder.ToString();
            }
        }

        /// <summary>
        /// 构造表单请求数据
        /// </summary>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        private string BuildFormBody(Dictionary<string, string> requestParam)
        {
            StringBuilder urlBuilder = new StringBuilder();
            if (requestParam != null && requestParam.Count > 0)
            {
                foreach (string key in requestParam.Keys)
                {
                    urlBuilder.Append(key).Append("=").Append(requestParam[key]).Append("&");
                }
            }
            return urlBuilder.ToString();
        }

        /// <summary>
        /// 构造请求头
        /// </summary>
        /// <param name="httpWebRequest"></param>
        /// <param name="headerParam"></param>
        private void BuildRequestHeader(HttpWebRequest httpWebRequest, Dictionary<string, string> headerParam)
        {
            if (httpWebRequest != null && headerParam != null && headerParam.Count > 0)
            {
                foreach (string key in headerParam.Keys)
                {
                    if (key.Equals("content-type", StringComparison.CurrentCultureIgnoreCase))
                    {
                        httpWebRequest.ContentType = headerParam[key];
                    }
                    else if (key.Equals("accept", StringComparison.CurrentCultureIgnoreCase))
                    {
                        httpWebRequest.Accept = headerParam[key];
                    }
                    else if (key.Equals("user-agent", StringComparison.CurrentCultureIgnoreCase))
                    {
                        httpWebRequest.UserAgent = headerParam[key];
                    }
                    else if (key.Equals("referer", StringComparison.CurrentCultureIgnoreCase))
                    {
                        httpWebRequest.Referer = headerParam[key];
                    }
                    else
                    {
                        httpWebRequest.Headers.Add(key, headerParam[key]);
                    }
                }
            }
        }

    }
}
