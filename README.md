<div align="center">
    <h1>R A I s o</h1>
    <p>RAiso is a renowned online store specializing in stationery products. It is built with <b>ASP.NET</b>.</p>
</div>

<div align="justify">

<table><thead>
  <tr>
    <th colspan="3" align="center"><b>Layers Overview</b></th>
  </tr></thead>
<tbody>
  <tr>
    <td colspan="3" align="center"><i>RAiso follows a layered architecture to ensure separation of concerns and maintainability. Each layer has distinct responsibilities:<i></td>
  </tr>
  <tr>
    <td><i>Views</i></td>
    <td colspan="2">The View layer is responsible for displaying information to the user and interpreting user commands. This layer encompasses all user interfaces in the project.</td>
  </tr>
  <tr>
    <td><i>Controller</i></td>
    <td colspan="2">The Controller layer is responsible for validating all input from the View layer. It delegates user requests to the lower layers for further processing.</td>
  </tr>
  <tr>
    <td><i>Handler</i></td>
    <td colspan="2">The Handler layer manages all business logic required in the application. It delegates database query tasks (select, insert, update, delete) to the Repository layer. Note that a single handler can access multiple repositories.</td>
  </tr>
  <tr>
    <td><i>Repository</i></td>
    <td colspan="2">The Repository layer provides access to the database and the Model layer via its public interfaces. It manipulates objects, encapsulating actual data manipulation operations in the database. The Repository also includes methods to select objects based on criteria and return fully instantiated objects or collections of objects that meet those criteria.</td>
  </tr>
  <tr>
    <td><i>Factory</i></td>
    <td colspan="2">The Factory layer encapsulates complex object creation. For example, when the client needs to create an aggregate object (an object that holds references to other objects), the Factory provides an interface for creating these objects. It is crucial that objects returned by the Factory are in a consistent state.</td>
  </tr>
  <tr>
    <td><i>Model</i></td>
    <td colspan="2">The Model layer represents business concepts or information about the business situation. This layer is managed using the Entity Framework tool.</td>
  </tr>
</tbody>
</table>

---

By adhering to this structured approach, RAiso ensures maintainability, scalability, and clear separation of responsibilities across its architecture, providing a robust system for its online stationery store.
