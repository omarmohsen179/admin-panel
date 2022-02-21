import React from "react";
import { FormGroup, Input } from "reactstrap";
const LabeledInput = ({ Label, value, HandleChange, name, type = "Text" }) => {
  return (
    <FormGroup>
      <label>{Label}</label>
      <Input
        style={{ height: "40px" }}
        id={name}
        value={value}
        onChange={(e) => HandleChange(e.target.value, name)}
        type={type}
      />
    </FormGroup>
  );
};

export default LabeledInput;
