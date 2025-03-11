interface PaymentService {
    void processPayment(double amount);
}

class CreditCardPaymentService implements PaymentService {
    public void processPayment(double amount) {
        System.out.println("Processing credit card payment of: " + amount);
    }
}

class OrderService {
    private final PaymentService paymentService;

    public OrderService(PaymentService paymentService) {
        this.paymentService = paymentService;
    }

    public void processOrder(double amount) {
        paymentService.processPayment(amount);
        System.out.println("Order processed successfully!");
    }
}

public class Main {
    public static void main(String[] args) {
        PaymentService paymentService = new CreditCardPaymentService();
        OrderService orderService = new OrderService(paymentService);

        orderService.processOrder(100.0);
    }
}
