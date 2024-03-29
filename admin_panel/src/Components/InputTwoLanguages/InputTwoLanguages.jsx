import React from "react";
import { FormGroup, Input, Row, Col } from "reactstrap";

const InputTwoLanguages = ({
  id,
  label,
  value,
  valueEn,
  enDisabled = false,
  maxLength = 10000000000000,
  DisabledAnotherLangue = false,
  onValueChange,
}) => {
  return (
    <>
      <Row style={{ width: "100%" }}>
        <Col className="pr-1" md="6">
          <FormGroup>
            <label>{label}</label>
            <Input
              id={id}
              value={value}
              disabled={DisabledAnotherLangue}
              onChange={(e) => onValueChange(e.target.value, e.target.id)}
              type="text"
              maxLength={maxLength}
            />
          </FormGroup>
        </Col>
        <Col className="pr-1" md="6">
          <FormGroup>
            <label>{label} English</label>
            <Input
              id={id + "En"}
              value={valueEn}
              disabled={enDisabled}
              onChange={(e) => onValueChange(e.target.value, e.target.id)}
              type="text"
              maxLength={maxLength}
            />
          </FormGroup>
        </Col>
      </Row>
    </>
  );
};

export default InputTwoLanguages;
