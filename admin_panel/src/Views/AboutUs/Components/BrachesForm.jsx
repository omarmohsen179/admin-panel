import React, { useCallback, useEffect, useRef, useState } from "react";
import { Card, FormGroup, CardBody, CardHeader, Button } from "reactstrap";
import SubmitButtons from "../../../Components/Buttons/SubmitButtons";
import InputTwoLanguages from "../../../Components/InputTwoLanguages/InputTwoLanguages";
import NumbersList from "./NumbersList";
function BranchesForm({ data, setdata }) {
  let NumberDefualtValues = useRef({
    Id: 0,
    PhoneNumber: "",
    Active: false,
    BranchId: 0,
  });
  const HandleChange = useCallback(
    (value, id) => {
      setdata({
        ...data,
        [id]: value,
      });
    },
    [data]
  );
  const HandleChangeNumbers = useCallback(
    (value) => {
      setdata({
        ...data,
        Numbers: value,
      });
    },
    [data]
  );
  let counter = useRef(0);
  let NewDefinion = useCallback(() => {
    if (!data.Numbers) {
      data.Numbers = [{ ...NumberDefualtValues.current }];
    } else {
      counter.current -= 1;
      data.Numbers?.push({
        ...NumberDefualtValues.current,
        Id: counter.current,
      });
    }
    setdata({
      ...data,
      Numbers: data.Numbers,
    });
  }, [data]);
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
      <NumbersList data={data.Numbers} setdata={HandleChangeNumbers} />

      <Button
        className="btn btn btn-success col-12"
        onClick={NewDefinion}
        //  disabled={
        //    Sevice.programDefinitionList?.find((e) => e.id == 0)
        //      ? true
        //     : false
        // }
        // onClick={saveHandle}
      >
        +
      </Button>
    </div>
  );
}

export default BranchesForm;
