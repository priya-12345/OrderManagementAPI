# OrderManagement
API that manages Order

API Endpoints

1) Get All Orders:

Endpoint: GET /api/orders
Description: Retrieves a list of all orders. Authorization: Requires the ViewOrdersPolicy policy.

2) Get an Order by ID:

Endpoint: GET /api/orders/{id}
Description: Retrieves an order by its ID. Authorization: Requires the ViewOrdersPolicy policy.

3) Add a New Order:

Endpoint: POST /api/orders
Description: Creates a new order. Authorization: Requires the AddOrdersPolicy policy.

4) Delete an Order by ID:

Endpoint: DELETE /api/orders/{id}
Description: Deletes an order by its ID. Authorization: Requires the DeleteOrdersPolicy policy.