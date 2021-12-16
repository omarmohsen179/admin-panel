import React, { useCallback, useEffect, useState } from "react";
import { Card, FormGroup, CardBody, CardHeader } from "reactstrap";
import SubmitButtons from "../../../Components/Buttons/SubmitButtons";
import InputTwoLanguages from "../../../Components/InputTwoLanguages/InputTwoLanguages";
import NumbersList from "./NumbersList";
function BranchesForm({ data, setdata }) {
  const HandleChange = useCallback(
    (value, id) => {
      setdata({
        ...data,
        [id]: value,
      });
    },
    [data]
  );

  return (
    <div style={{ width: "100%" }}>
      <FormGroup>
        <InputTwoLanguages
          id="Country"
          label={"Country"}
          onValueChange={HandleChange}
          value={data?.Country}
          valueEn={data?.CountryEn}
        />
      </FormGroup>
      <FormGroup>
        <InputTwoLanguages
          id="City"
          label={"City"}
          onValueChange={HandleChange}
          value={data?.City}
          valueEn={data?.CityEn}
        />
      </FormGroup>
      <FormGroup>
        <InputTwoLanguages
          id="Address"
          label={"Address"}
          onValueChange={HandleChange}
          value={data?.Address}
          valueEn={data?.AddressEn}
        />
      </FormGroup>

      <FormGroup>
        <label htmlFor="isActive" className="d-block">
          Is Active
        </label>
        <input
          style={{
            width: "40px",
            height: "40px",
          }}
          type="checkbox"
          checked={data?.Active}
          id="Active"
          onChange={(e) => HandleChange(e.target.checked, e.target.id)}
        />
      </FormGroup>
      <NumbersList />
    </div>
  );
}

export default BranchesForm;
