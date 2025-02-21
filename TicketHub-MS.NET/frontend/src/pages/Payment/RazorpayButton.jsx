import React from "react";

const RazorpayButton = ({ handlePayment }) => {
  return (
    <button
      onClick={handlePayment}
      style={{
        padding: "10px 20px",
        fontSize: "16px",
        backgroundColor: "#3399cc",
        color: "#fff",
        border: "none",
        borderRadius: "5px",
        cursor: "pointer",
      }}
      className="btn btn-info"
    >
      Pay Now
    </button>
  );
};

export default RazorpayButton;
