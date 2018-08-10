## Step 2: The only true wisdom is in knowing

In Step 2, we build upon the code in Step 1 by adding [Payment Response Handling](https://payabbhi.com/docs/integration/#payment-response-handling).

After successful payment, the JavaScript handler submits the `Payment response` to the `Status` page.

In status function, we verify the `Payment response` via the utility function in the client library.
