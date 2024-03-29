import React from "react";
import { Card, CardBody, CardHeader } from "reactstrap";

const CardForm = ({ title, onSubmit, children }) => {
  return (
    <Card className="card-user">
      <CardHeader>
        <h4>{title}</h4>
      </CardHeader>
      <CardBody>
        <form
          onSubmit={(e) => {
            e.preventDefault();
            onSubmit();
          }}
          style={{
            height: "500px",
            overflowY: "auto",
            overflowX: "hidden",
          }}
        >
          {children}
        </form>
      </CardBody>
    </Card>
  );
};

export default CardForm;
