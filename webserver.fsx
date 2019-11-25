// --------------------------------------------------------------------------------------
// Start up Suave.io
// --------------------------------------------------------------------------------------

#r "packages/FAKE/tools/FakeLib.dll"
#r "packages/Suave/lib/net40/Suave.dll"

open Fake
open Suave
open Suave.Successful 
open Suave.Http.Successful
open Suave.Web
open Suave.Types
open System.Net
open App

let hostName = System.Net.IPAddress.Parse "0.0.0.0"

DotLiquid.setTemplatesDir (sprintf "%s/templates/" __SOURCE_DIRECTORY__)
DotLiquid.setCSharpNamingConvention()
let serverConfig = 
    let port = getBuildParamOrDefault "port" "8083" |> Sockets.Port.Parse
    { defaultConfig with bindings = [ HttpBinding.create HTTP IPAddress.Loopback port ] }
  
// startWebServer serverConfig App.Router

startWebServer serverConfig 
    (OK  
        ("Hello World! It's Suave.io on Azure Websites.<br /><ul>" + 
          "<li>Sample git Repo: <a href='https://github.com/shanselman/suavebootstrapper'>https://github.com/shanselman/suavebootstrapper</a></li>" +
          "<li>Intro blog post: <a href='http://www.hanselman.com/blog/RunningSuaveioAndFWithFAKEInAzureWebAppsWithGitAndTheDeployButton.aspx'>http://www.hanselman.com/blog/RunningSuaveioAndFWithFAKEInAzureWebAppsWithGitAndTheDeployButton.aspx</a></li>" +
          "</ul>"))

