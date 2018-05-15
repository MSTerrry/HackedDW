using DeliveryWizard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LicenseGenerator
{
    class Program
    {
        private static void GenerateNewKeyPair()
        {

            string withSecret;

            string woSecret;

            using (var rsaCsp = new RSACryptoServiceProvider())
            {
                withSecret = rsaCsp.ToXmlString(true);
                woSecret = rsaCsp.ToXmlString(false);
            }
            File.WriteAllText("private.xml", withSecret);
            File.WriteAllText("public.xml", woSecret);
        }
        static void Main(string[] args)
        {
            if (args.Any(a => a == "--generate"))
            {
                GenerateNewKeyPair();
            }

            var dto = new License()
            {
                ValidUntil = DateTime.Now.AddDays(14)
            };

            var fileName = string.Join("", DateTime.Now.ToString().Where(c => char.IsDigit(c)));
            new LicenceGenerator().CreateLicenseFile(dto, fileName + ".dw_licence");
        }

        class LicenceGenerator
        {
            private static string PrivateKey = @"<RSAKeyValue>
            <Modulus>1KRyoFOasCEkfN5zcEF/c/iyC2CcnobXrHJnrtytceZHl9yWpuj/rfrJ/zOH/ebQjE2tqPW3Wi8wYEsfGOExRXZvs3KILx6AmlauBqde1JzAlbVaX/GaoqN41rcjffLg3v0FGyNuuzQKADR7NKofb+MnbAJyDiTyCfNmt0tDQGE=</Modulus>
            <Exponent>AQAB</Exponent>
            <P>4aRHXgu02GS3/O/zWPAXiINok4BhwuE1Dw3koDnh6c3t9kJt9jcSMdNxozsWOPCA5ffhxwrmc5Ej8rHxtEEVkw==</P>
            <Q>8UBvmx0dZqrJHxdI8oE3XPRASHV08fAwGXOYyz83gXYp1ZyJpsaY/KTFGemjCa6OpUsfZrhUczwsGO07YBRKuw==</Q>
            <DP>D44ptVwNPZXD8VYBarIyjSCyBukk1DB+XelRR5J19o5Rx1ZRClZFlNXE0cHzCD3cRP5PvE8OEA2Dcum9hfWurQ==</DP>
            <DQ>Yy14NC5N7ez77XonFPqmBeKrop4Wy3dQbsYk5DlC2kf3fsdxl0xBjGs4VCTGT66hGba+W/4fSZhNEJpGNINjDQ==</DQ>
            <InverseQ>0wa3lnoLu0mw93xgqN8IAE/zwINRaaYm1BJk+kFuvbnmwNv2qj84oCl77NXKtNyeB93g2tqv0MXHiSbpfleBcg==</InverseQ>
            <D>jhTrenEidPlQNhc1Lxa0oLrVzIBbZhlXVqSC3vYY9ngV8kS0bQZWgNuHyPuXrHFje7wTg0fboWjSfCT1vFwL3NQT9CrtK1MpcOAdviy6gpQ7J/cCFCkHlgrp50KFsfJjMT2H7EjSlxABn4obwQ0hXD6eIzvFLOTjCUzzqUiWnRk=</D>
            </RSAKeyValue>";
            public void CreateLicenseFile(License dto, string fileName)
            {

                var ms = new MemoryStream();

                new XmlSerializer(typeof(License)).Serialize(ms, dto);

                // Create a new CspParameters object to specify
                // a key container.
                
                // Create a new RSA signing key and save it in the container.
                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
                rsaKey.FromXmlString(PrivateKey);

                // Create a new XML document.
                XmlDocument xmlDoc = new XmlDocument();

                // Load an XML file into the XmlDocument object.
                xmlDoc.PreserveWhitespace = true;
                ms.Seek(0, SeekOrigin.Begin);
                xmlDoc.Load(ms);

                // Sign the XML document.
                SignXml(xmlDoc, rsaKey);

                // Save the document.
                xmlDoc.Save(fileName);
            }

            // Sign an XML file.
            // This document cannot be verified unless the verifying
            // code has the key with which it was signed.
            public static void SignXml(XmlDocument xmlDoc, RSA Key)
            {
                // Check arguments.
                if (xmlDoc == null)
                    throw new ArgumentException("xmlDoc");
                if (Key == null)
                    throw new ArgumentException("Key");

                // Create a SignedXml object.
                SignedXml signedXml = new SignedXml(xmlDoc);

                // Add the key to the SignedXml document.
                signedXml.SigningKey = Key;

                // Create a reference to be signed.
                Reference reference = new Reference();
                reference.Uri = "";

                // Add an enveloped transformation to the reference.
                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(env);

                // Add the reference to the SignedXml object.
                signedXml.AddReference(reference);

                // Compute the signature.
                signedXml.ComputeSignature();

                // Get the XML representation of the signature and save
                // it to an XmlElement object.
                XmlElement xmlDigitalSignature = signedXml.GetXml();

                // Append the element to the XML document.
                xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
            }
        }
    }
}

