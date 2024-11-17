
/*
When a Customer rents a Vehicle an Invoice is created. 
A Bill then goes out periodically for one or more Invoices, 
until all Invoices for that Customer are paid in full.
A Customer with an O/S Bill cannot rent a Vehicle.
There are no reservations.
Version 2: reservations, map location of vehicle and fleet. Driving history.
*/
ASPNETCoreInvoice:
1. Invoice
2. Customer
3. Vehicle
4. Bill