using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Helper
{
    class Constant
    {
        private string _baseUrl;
        public Constant(string _baseUrl)
        {
            this._baseUrl = _baseUrl;
            Console.WriteLine(_baseUrl);
        }
        public string user_uri { get {
                if (string.IsNullOrEmpty(_baseUrl))
                    throw new Exception(" _baseUr is null ");
                return _baseUrl + "/api/UTILISATEURs";
            }  
            }
        public string group_uri
        {
            get
            {
                if (string.IsNullOrEmpty(_baseUrl))
                    throw new Exception(" _baseUr is null ");
                return _baseUrl + "/api/UTILISATEURSGRPs";
            }
        }

        public string tiers_uri { get {
                if (string.IsNullOrEmpty(_baseUrl))
                    throw new Exception(" _baseUr is null ");
                return _baseUrl + "/api/TIERs";
            }
        }
        public string piece_nature_uri
        {
            get
            {
                if (string.IsNullOrEmpty(_baseUrl))
                    throw new Exception(" _baseUr is null ");
                return _baseUrl + "/api/PIECE_NATUREs";
            }
        }
        public string depot_url
        {
            get
            {
                if (string.IsNullOrEmpty(_baseUrl))
                    throw new Exception(" _baseUr is null ");
                return _baseUrl + "/api/DEPOTs";
            }
        }

    }
}
