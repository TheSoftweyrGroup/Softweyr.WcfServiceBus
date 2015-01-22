Softweyr.WcfServiceBus
======================

Extension to WCF allowing for simplified client access to services and a simplified &quot;Service Bus&quot; API.

The following SOA messaging patterns are supported (with examples),

* Fire-and-forget: (1 to 1 Request):

    <code>WcfServiceBus.Invoke&lt;IMyServiceContract&gt;(client => client.DoStuff("Get to work!"));</code>

* Request-Response (1 to 1 Request, 1 to 1 Response):

    <code>var response = WcfServiceBus.Request&lt;IMyServiceContract&gt;(client => client.DoStuff("What is 1+1?"));</code>
    
    or
    
    <code>
    ServiceEndpoint responseEndpoint;    
    WcfServiceBus.Request&lt;IMyServiceContract&gt;(client => client.DoStuff("What is 1+1?"), responseEndpoint);   
    </code>

* Publish (1 to 0...N Request):

    <code>WcfServiceBus.Publish&lt;IMyServiceContract&gt;(client => client.DoStuff("Lunch is ready!"));</code>

* Notify (1 to 1...N Request):

    <code>WcfServiceBus.Notify&lt;IMyServiceContract&gt;(client => client.DoStuff("Someone needs to get this job done!"));</code>

* Probe (1 to 0...N Request, 0...N to 1 Response):

    <p><code>var responses = WcfServiceBus.Probe&lt;IMyServiceContract&gt;(client => client.DoStuff("Anyone There?"), TimeSpan.FromSeconds(30));</code>  
    
    or  
    
    <code>ServiceEndpoint responseEndpoint;    
    WcfServiceBus.Probe&lt;IMyServiceContract&gt;(client => client.DoStuff("Anyone There?"), responseEndpoint);
    </code></p>
    
Publish and Notify have the following utility methods that are supported when using the WcfServiceBus discovery proxy. 
Endpoint susbcriptions can however be simply added to the service.model/client section of a configuration file or manually
added to the WcfServiceBus discovery proxy

* Susbcribe

    <code>WcfServiceBus.Subscribe&lt;IMyServiceContract&gt;();</code>  
    
    or  
    
    <code>    ServiceEndpoint endpoint;  
    WcfServiceBus.Subscribe&lt;IMyServiceContract&gt;(endpoint);</code>

* Unsubscribe

    <code>WcfServiceBus.Unsubscribe&lt;IMyServiceContract&gt;();</code>  
    
    or  
    
    <code>    ServiceEndpoint endpoint;  
    WcfServiceBus.Unsubscribe&lt;IMyServiceContract&gt;(endpoint);</code>

Endpoint Configuration
----------------------

<p>Adding endpoints to the client part of a configuration file is the easiest way to add client endpoints.<p>
<p>
    <b>Note:</b> the only caveate is you need to make sure every endpoint has a unique name.
</p>
<p><code>&lt;system.servicemodel&gt;
        &lt;client&gt;
        &lt;/client&gt;
    &lt;/system.servicemodel&gt;</code></p>
