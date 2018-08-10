# Step 3: To every rule there is an exception

In Step 3, we further enhance the code by adding basic `error handling` and also show you how to debug any possible errors in your code.

Refer to [Exception Handling](https://payabbhi.com/docs/api/#errors) for documentation of exception classes.

----

First deliberately introduce changes in the arguments to see the error flows.
e.g. change the amount argument to `Create Order` to an amount less that ₹1 or leave out required arguments to `Checkout` or pass an incorrect paymentID to the `verifyPaymentSignature` method etc.

Now open step3/index.html to see how the error message from the `Payabbhi Client Library` is displayed in the page.

Check the code to see how the `Library Exceptions`, which typically wrap the [API Errors](https://payabbhi.com/docs/api#errors), are handled.

-----

 For `Checkout flows` in test mode, you may deliberately not use the [Test Cards](https://payabbhi.com/docs/account) to try out the validations.

 You may also choose to click on the `Declined` button in `test mode` to see the alternative flow.

 For failed payments, you may check the `error_code` and `error_description` attributes via [Payments API](https://payabbhi.com/docs/api/#payments) or the [Portal Payments List](https://payabbhi.com/portal/payments).
