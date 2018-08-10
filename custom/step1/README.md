## Step 1: Start small

Step 1 is the first level of our tutorial. We build a Superhero Store where a superhero can be purchased by paying a random amount between ₹1 to ₹5.

The `Payments Acceptance workflow` is implemented as described in the Payabbhi [Integration Guide](https://payabbhi.com/docs/integration).

Make sure you have already set up your web server, installed the Payabbhi `Python Client library`, signed up for your [Payabbhi Account](https://payabbhi.com/docs/account) and downloaded the [API keys](https://payabbhi.com/docs/account/#api-keys) from the [Portal](https://payabbhi.com/portal).

Now, replace the `<ACCESS-ID>` and `<SECRET-KEY>` with your keys and then hit the root url i.e. http://127.0.0.1:5000/ in your browser.

------

Browse the code to check how the [Payments Acceptance workflow](https://payabbhi.com/docs/integration) is implemented.

1. We first create a Payabbhi order by calling the `Create Order API`.

2. Then we integrate with Payabbhi `Custom Checkout` as per [Web Checkout](https://payabbhi.com/docs/checkout) Guide.

3. For `Checkout flows` in test mode, we use [Test Cards](https://payabbhi.com/docs/account).

4. After successful payment, the JavaScript handler submits the `Payment response` to the `Status` page.

5. Then we display the success message to the customer along with the orderID and paymentID.

----

To verify your integration, you can call the [Payments API](https://payabbhi.com/docs/api/#payments) or you can check the [Portal Payments List](https://payabbhi.com/portal/payments).
