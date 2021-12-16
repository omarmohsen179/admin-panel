import REQUEST from "../../Services/Request";

export const INVENTORY = async (e, status) => {
  return await REQUEST({
    method: "get",
    url: "Inventory/admin",
  });
};
export const INVENTORY_INSERT = async (e) => {
  return await REQUEST({
    method: "post",
    url: "Inventory",
    data: e,
  });
};
export const INVENTORY_UPDATE = async (e) => {
  return await REQUEST({
    method: "put",
    url: "Inventory",
    data: e,
  });
};
export const INVENTORY_DELETE = async (id) => {
  return await REQUEST({
    method: "delete",
    url: "Inventory/" + id,
  });
};

export const BRANCHES = async (e, status) => {
  return await REQUEST({
    method: "get",
    url: "Branch/admin",
  });
};
export const BRANCHES_INSERT = async (e) => {
  return await REQUEST({
    method: "post",
    url: "Branch",
    data: e,
  });
};
export const BRANCHES_UPDATE = async (e) => {
  return await REQUEST({
    method: "put",
    url: "Branch",
    data: e,
  });
};
export const BRANCHES_DELETE = async (id) => {
  return await REQUEST({
    method: "delete",
    url: "Branch/" + id,
  });
};
export const NUMBER_DELETE = async (id) => {
  return await REQUEST({
    method: "delete",
    url: "Branch/" + id,
  });
};
