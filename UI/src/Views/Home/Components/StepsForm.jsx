import React, { useCallback } from "react";
import { FormGroup } from "reactstrap";

import InputTwoLanguages from "../../../Components/InputTwoLanguages/InputTwoLanguages";
function StepsForm({ data, setdata }) {
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
          id="Title"
          label={"Title"}
          onValueChange={HandleChange}
          value={data?.Title}
          valueEn={data?.TitleEn}
        />
      </FormGroup>
      <FormGroup>
        <InputTwoLanguages
          id="Description"
          label={"Description"}
          onValueChange={HandleChange}
          value={data?.Description}
          valueEn={data?.DescriptionEn}
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
    </div>
  );
}

export default StepsForm;
