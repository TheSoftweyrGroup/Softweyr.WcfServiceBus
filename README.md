Softweyr.WcfServiceBus
======================

Extension to WCF allowing for a simplified &quot;Service Bus&quot; type API

The example below will invoke <ul>a</ul> service that implements the IMyServiceContract service contract
that is in either the client part of the configuration file or can be found using WCF discovery.

<p><code>WcfServiceBus.Invoke<IMyServiceContract>(client => client.DoStuff("Hello World"));</code></p>