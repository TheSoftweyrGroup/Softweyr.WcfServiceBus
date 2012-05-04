Softweyr.WcfServiceBus
======================

Extension to WCF allowing for simplified client access to services and a simplified &quot;Service Bus&quot; API.

The following SOA messaging patterns are supported (with examples),

* Fire-and-forget: (1 to 1 Request):

    <code>WcfServiceBus.Invoke&lt;IMyServiceContract&gt;(client => client.DoStuff("Hello World"));</code>

* Request-Response (1 to 1 Request, 1 to 1 Response):

    <code>var response = WcfServiceBus.Request&lt;IMyServiceContract&gt;(client => client.DoStuff("Hello World"));</code>

* Publish (1 to 0...N Request):

    <code>WcfServiceBus.Publish&lt;IMyServiceContract&gt;(client => client.DoStuff("Hello World"));</code>

* Notify (1 to 1...N Request):

    <code>WcfServiceBus.Notify&lt;IMyServiceContract&gt;(client => client.DoStuff("Hello World"));</code>

* Probe (1 to 0...N Request, 0...N to 1 Response):

    <code>var responses = WcfServiceBus.Probe&lt;IMyServiceContract&gt;(client => client.DoStuff("Hello World"));</code>

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