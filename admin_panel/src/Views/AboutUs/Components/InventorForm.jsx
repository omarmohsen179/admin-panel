import React, { useCallback, useEffect, useState } from "react";
import { Card, FormGroup, CardBody, CardHeader } from "reactstrap";

import InputTwoLanguages from "../../../Components/InputTwoLanguages/InputTwoLanguages";
import UploadImageButton from "../../../Components/UploadImageButton/UploadImageButton";
import { ApiBaseUrl } from "../../../Services/config.json";
function InventorForm({ data, setdata }) {
  const HandleChange = useCallback(
    (value, id) => {
      setdata({
        ...data,
        [id]: value,
      });
    },
    [data]
  );
  let handleGetImages = (event) => {
    let files = event.target.files;
    setdata({ ...data, Image: files[0], ImagePath: "" });
  };

  let handleRemoveImage = useCallback(() => {
    setdata({ ...data, Image: "", ImagePath: "" });
  }, [data]);
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
      <div className="row">
        <div className="col">
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
        <div className="col">
          <FormGroup className="image__button">
            <label>{"Image"} </label>
            <UploadImageButton
              isMultiple={false}
              handleGetImages={handleGetImages}
              handleRemoveImage={handleRemoveImage}
              imagesFiles={
                data.ImagePath || data.Image
                  ? [data.ImagePath ? ApiBaseUrl + data.ImagePath : data.Image]
                  : []
              }
            />
          </FormGroup>
        </div>
      </div>
    </div>
  );
}

export default InventorForm;
