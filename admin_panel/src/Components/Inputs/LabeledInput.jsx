import React from "react";
import { FormGroup, Input } from "reactstrap";
const LabeledInput = ({ Label, value, HandleChange, type }) => {
  return (
    <FormGroup>
      <label>{Label}</label>
      <Input
        style={{ height: "40px" }}
        id={"link"}
        value={value}
        onChange={HandleChange}
        type={type}
      />
    </FormGroup>
  );
};

export default LabeledInput;
