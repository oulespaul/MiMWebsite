<template>
  <div>
    <form>
      <button id="checkout-button" style="display:none;">Pay with credit card</button>
      <v-btn @click="pay">จ่าย</v-btn>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import swal from 'sweetalert2'
export default {
  mounted() {
    OmiseCard.configure({
      publicKey: "pkey_test_5gyy5c8qvcpfbn6mfut",
      frameLabel: "MIM",
      submitLabel: "PAY NOW",
      currency: "thb"
    });

    OmiseCard.attach();
  },
  props: ["trxId", "amount"],
  // watch: {
  //   testProp: function(newVal, oldVal) {
  //     this.pay();
  //   }
  // },
  methods: {
    creditCardConfigure() {
      OmiseCard.configure({
        defaultPaymentMethod: "credit_card",
        otherPaymentMethods: []
      });
      OmiseCard.configureButton("#checkout-button");
      OmiseCard.attach();
    },
    omiseCardHandler() {
      OmiseCard.open({
        frameDescription: "Invoice #999",
        amount: this.amount * 100,
        onCreateTokenSuccess: token => {
          let data = {
            email: "test@gmail.com",
            name: "test",
            amount: this.amount * 100,
            token: token
          };
          const headers = {
            "Content-Type": "application/json"
          };
          axios
            .post("https://localhost:5001/transaction/omise", data, {
              headers: headers
            })
            .then(result => {
              let data = {
                id: this.trxId,
                TrxStatus: "จ่ายเงินสำเร็จแล้ว"
              };
              axios
                .post("https://localhost:5001/transaction/updateStatus", data)
                .then(result => {
                  swal.fire('จ่ายเงินสำเร็จแล้ว','','success').then(()=>{
                    window.location.replace('/#/dashboard')
                  })
                })
                .catch(err => {
                  swal.fire('จ่ายเงินไม่สำเร็จ','','error')
                });
            })
            .catch(err => {
              console.log(err);
            });
        },
        onFormClosed: () => {}
      });
    },
    pay() {
      if (event) event.preventDefault();
      this.creditCardConfigure();
      this.omiseCardHandler();
    }
  }
};
</script>
<style scoped>
</style>